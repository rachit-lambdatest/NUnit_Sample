using Microsoft.Playwright;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TestFixtureTwo : LambdaTestSetup
{
    [Test]
    public async Task TestMethodThree()
    {
        await page.GotoAsync("https://www.bing.com");
        string title = await page.TitleAsync();

        if (title.Contains("Search - Microsoft Bing")) {
            await SetTestStatus("passed", "Title matched", page);
        }
        else {
            await SetTestStatus("failed", "Title not matched", page);
        }
        Assert.IsTrue(title != null);
    }

    [Test]
    public async Task TestMethodFour()
    {
        await page.GotoAsync("https://www.lambdatest.com");
        string title = await page.TitleAsync();

        if (title.Contains("Power Your Software Testing with AI and Cloud | LambdaTest")) {
            await SetTestStatus("passed", "Title matched", page);
        }
        else {
            await SetTestStatus("failed", "Title not matched", page);
        }
        Assert.IsTrue(title != null);
    }
    public static async Task SetTestStatus(string status, string remark, IPage page)
    {
        await page.EvaluateAsync("_ => {}",
            $"lambdatest_action: {{\"action\": \"setTestStatus\", \"arguments\": {{\"status\":\"{status}\", \"remark\": \"{remark}\"}}}}");
    }
}
