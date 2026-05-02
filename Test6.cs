using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]

[TestFixture]
public class Test6 : PageTest
{
    [Test]
    public async Task CreateAssetAndCheckHistory()
    {
        // Adding a time out to handle any potential loading issues/slow response from the server
        await Page.GotoAsync("https://demo.snipeitapp.com/login", new() 
         { 
           Timeout = 30000 
         });   

        //  Login to the demo application
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("admin");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

        // Create asset 
        await Page.GetByText("Create New", new() { Exact = true }).ClickAsync();
        await Page.GetByRole(AriaRole.Navigation).GetByText("Asset", new() { Exact = true }).ClickAsync();
        await Page.Locator("#select2-model_select_id-container").ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox).FillAsync("Mac");
        await Page.GetByText("Laptops - Macbook Pro 13\" (#").ClickAsync();
        await Page.GetByLabel("Select Status").GetByText("Select Status").ClickAsync();
        await Page.GetByRole(AriaRole.Option, new() { Name = "Ready to Deploy" }).ClickAsync();
        
        //declaring a variable for unique asset tag to use for searching the asset later in the test
        var assetTag = await Page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).InputValueAsync();
        
        //saving the created asset
        await Page.Locator("button[name=\"submit\"]").ClickAsync();

        //Search for the created asset using the unique asset tag 
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).ClickAsync();
        await Page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).FillAsync(assetTag);
        await Page.Keyboard.PressAsync("Enter");
      
        // Click on the asset from the search result to navigate to the History page
        await Page.Locator("#assetsListingTable").GetByRole(AriaRole.Link, new() { Name = assetTag }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "History" }).ClickAsync();
        await Page.WaitForTimeoutAsync(5000); // Adding a wait to ensure the history page loads before we attempt to logout
        // logout from the application
        await Page.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Link, new() { Name = "Admin User" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
    }
}


