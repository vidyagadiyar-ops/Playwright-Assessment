using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]

[TestFixture]
public class Test4 : PageTest
{
    [Test]
    public async Task CreateAssetAndCheckHistory()
    {
        await Page.GotoAsync("https://demo.snipeitapp.com/login", new() 
         { 
           Timeout = 30000 
         });   
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("admin");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        await Page.GetByText("Create New", new() { Exact = true }).ClickAsync();
        await Page.GetByRole(AriaRole.Navigation).GetByText("Asset", new() { Exact = true }).ClickAsync();
        await Page.Locator("#select2-model_select_id-container").ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox).FillAsync("Mac");
        await Page.GetByText("Laptops - Macbook Pro 13\" (#").ClickAsync();
        await Page.GetByLabel("Select Status").GetByText("Select Status").ClickAsync();
        await Page.GetByRole(AriaRole.Option, new() { Name = "Ready to Deploy" }).ClickAsync();
        
        var assetTag = $"TEST{DateTime.UtcNow:yyyyMMddHHmmss}";
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).FillAsync(assetTag);
        
        await Page.Locator("button[name=\"submit\"]").ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).FillAsync(assetTag);
        await Page.Keyboard.PressAsync("Enter");
        // await Page.GetByLabel("", new() { Exact = true }).Nth(4).CheckAsync();
        await Page.Locator("#assetsListingTable").GetByRole(AriaRole.Link, new() { Name = assetTag }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "History" }).ClickAsync();
        // await Page.GetByRole(AriaRole.Cell, new() { Name = "Sat May 02, 2026 3:11AM" }).ClickAsync();
        await Page.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Link, new() { Name = "Admin User" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
    }
}

