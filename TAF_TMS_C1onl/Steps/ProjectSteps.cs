using OpenQA.Selenium;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Pages;

namespace TAF_TMS_C1onl.Steps;

public class ProjectSteps : BaseStep
{
    public ProjectSteps(IWebDriver driver) : base(driver)
    {
    }

    public void NavigateToAddProjectPage()
    {
        new AddProjectPage(Driver, true);
    }
    
    public void CreateProject(Project project)
    {
        
    }
}