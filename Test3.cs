using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Test3 : PageTest
{
    [Test]
    public async Task CreateAssetAndLogout()
    {
        
        await Page.GotoAsync("https://demo.snipeitapp.com/login");
        // await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("admin");
        // await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        await Page.GetByText("Create New", new() { Exact = true }).ClickAsync();
        await Page.GetByRole(AriaRole.Navigation).GetByText("Asset", new() { Exact = true }).ClickAsync();
        // await Page.Locator("#select2-company_id-jn-container").ClickAsync();
        // await Page.GetByLabel("Select Company").GetByText("Select Company").ClickAsync();
        // await Page.GetByText("Abernathy-Stracke").ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).ClickAsync();
        var assetTag = await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag" })
         .InputValueAsync();
        // await Page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).ClickAsync();
        // await Page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).FillAsync("123456");
        await Page.Locator("#select2-model_select_id-container").ClickAsync();
        await Page.GetByText("Laptops - Macbook Pro 13\" (#").ClickAsync();
        await Page.GetByLabel("Select Status").GetByText("Select Status").ClickAsync();
        await Page.GetByRole(AriaRole.Option, new() { Name = "Ready to Deploy" }).ClickAsync();
        await Page.GetByLabel("Select a User").ClickAsync();
        await Page.GetByRole(AriaRole.Option).First.ClickAsync();
        // await Page.GetByText("Ardith Abbott (schaden.").ClickAsync();
        await Page.Locator("button[name=\"submit\"]").ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).AllAsync();
        await Page.Locator("input[name=\"btSelectItem\"]").Nth(5).CheckAsync();
        await Page.Locator("#assetsListingTable").GetByRole(AriaRole.Link, new() { Name = "" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "History" }).ClickAsync();
        await Page.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Link, new() { Name = "Admin User" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
    }
}
