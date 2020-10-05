namespace MyCOVID.Services.ReportingApi.Model.ProblemDetails
{
    public class InfectionValidationProblemDetail : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InfectionValidationProblemDetail()
        {
            Title = "Infection validation problem.";
            Detail = "Infections must be greater than 0.";
        }
    }
}