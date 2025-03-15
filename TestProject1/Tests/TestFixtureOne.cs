using Microsoft.Playwright;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TestFixtureOne : LambdaTestSetup
{
    [Test]
    public async Task TestMethodOne()
    {
        await page.GotoAsync("https://www.example.com");

        string title = await page.TitleAsync();
        if (title.Contains("Example Domain")) {
            await SetTestStatus("passed", "Title matched", page);
        }
        else {
            await SetTestStatus("failed", "Title not matched", page);
        }
        Assert.AreEqual("Example Domain", title);
    }

    [Test]
    public async Task TestMethodTwo()
    {
        await page.GotoAsync("https://www.google.com");

        string title = await page.TitleAsync();
        if (title.Contains("Google")) {
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
