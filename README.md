# BDDLight
Given Lightweight BDD Framework Then Package Installed.

## Usage

Create a scenario using **Scenario.Create()** and then specify **Given**, **And**, **When** and **Then**.

Example:

    var scenario = Scenario.Create();
    scenario.Given(ProgramLoaded)
      .And(UserClicksButton)
      .Then(ReceiptIsPrinted);
    Runner.RunScenario(scenario);

    void ProgramLoaded() {}
    void UserClicksButton() {}
    void ReceiptIsPrinter() {}
