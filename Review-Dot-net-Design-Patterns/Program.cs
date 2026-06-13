using Review_Dot_net_Design_Patterns.model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Serve wwwroot/index.html at "/"
app.UseDefaultFiles();
app.UseStaticFiles();

// In-memory store (keyed by Emp_id)
var employees = new Dictionary<int, Emp_data>();

// GET /api/employees — return all employees
app.MapGet("/api/employees", () => Results.Ok(employees.Values));

// GET /api/employees/{id}
app.MapGet("/api/employees/{id:int}", (int id) =>
    employees.TryGetValue(id, out var emp)
        ? Results.Ok(emp)
        : Results.NotFound(new { message = $"Employee {id} not found." }));

// POST /api/employees — create
app.MapPost("/api/employees", (Emp_data emp) =>
{
    if (employees.ContainsKey(emp.Emp_id))
        return Results.Conflict(new { message = $"Employee ID {emp.Emp_id} already exists." });

    var errors = EmpDataValidator.ValidateEmpData(emp);
    if (errors.Count > 0)
        return Results.BadRequest(new { errors });

    employees[emp.Emp_id] = emp;
    return Results.Created($"/api/employees/{emp.Emp_id}", emp);
});

// PUT /api/employees/{id} — update
app.MapPut("/api/employees/{id:int}", (int id, Emp_data updated) =>
{
    if (!employees.ContainsKey(id))
        return Results.NotFound(new { message = $"Employee {id} not found." });

    var errors = EmpDataValidator.ValidateEmpData(updated);
    if (errors.Count > 0)
        return Results.BadRequest(new { errors });

    updated.Emp_id = id;
    employees[id] = updated;
    return Results.Ok(updated);
});

// DELETE /api/employees/{id}
app.MapDelete("/api/employees/{id:int}", (int id) =>
{
    if (!employees.Remove(id))
        return Results.NotFound(new { message = $"Employee {id} not found." });
    return Results.NoContent();
});

app.Run();
