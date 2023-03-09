using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Pages;
using TestProject1.Tools;

namespace TestProject1.Tests
{
    [TestFixture]
    [Category("ToDo")]
    [AllureNUnit]
    public class TodoTest : TestRunner
    {
        private const string EXPECTED_ALERT_TEXT_ADD = "Task added to Inbox";
        private const string EXPECTED_TASK_NAME = "Edited task\r\nActivate to edit the task name";
        private const string EXPECTED_COMPLETE_ALERT_TEXT = "1 task completed";
        private const string EXPECTED_PROJECT_NAME = "Test project";
        private const string EXPECTED_ALERT_TEXT_MOVE = "Task moved to Home";

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void AddTask()
        {
            MainPage mainPage = new LoginPage(driver)
                 .SuccessfullLogin(Email, Password)
                 .ClickAddTaskButton()
                 .FillNewTaskData("Test task", "Test description")
                 .ClickSaveTaskButton();

            Assert.AreEqual(EXPECTED_ALERT_TEXT_ADD, mainPage.GetSuccessAlertText());
        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void DeleteTask()
        {
            new LoginPage(driver)
                 .SuccessfullLogin(Email, Password)
                 .OpenTask()
                 .ClickOptionButton()
                 .ClickDeleteTaskButton();

        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void EditTask()
        {
            TaskPage taskPage = new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .OpenTask()
                .EnterNewTaskName("Edited task")
                .ClickSaveButton();

            Assert.AreEqual(EXPECTED_TASK_NAME, taskPage.GetTaskNameFildText());
        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void CompleteTask()
        {
            TaskPage taskPage = new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .OpenTask()
                .ClickCompleteButton();

            Assert.AreEqual(EXPECTED_COMPLETE_ALERT_TEXT, taskPage.GetCompleteAlertText());
        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void SortByDueDate()
        {
            new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .ClickOptionsButton()
                .ClickSortingMenu()
                .SelectDueDateOption();

        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void SortByPriority()
        {
            new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .ClickOptionsButton()
                .ClickSortingMenu()
                .SelectPriorityOption();
        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void CreateProgect()
        {
            ProjectPage projectPage = new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .ClickAddProjectButton()
                .FillProjectName("Test project")
                .ClickAddProjectButton();

            Assert.AreEqual(EXPECTED_PROJECT_NAME, projectPage.GetProjectName());

        }

        [AllureTag("ToDo")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Khudo Bohdan")]
        [Test]
        public void MoveTask()
        {
            MainPage mainPage = new LoginPage(driver)
                .SuccessfullLogin(Email, Password)
                .ContextClickTask()
                .ClickMoveToProjectButton()
                .SelectHomeProject();

            Assert.AreEqual(EXPECTED_ALERT_TEXT_MOVE, mainPage.GetSuccessAlertText());

        }
    }
}
