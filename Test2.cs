using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new()
{
    Headless = false,
});
var context = await browser.NewContextAsync();

var page = await context.NewPageAsync();
await page.GotoAsync("https://demo.snipeitapp.com/login");
await page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("admin");
await page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("password");
await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
await page.GetByText("Create New", new() { Exact = true }).ClickAsync();
await page.GetByRole(AriaRole.Navigation).GetByText("Asset", new() { Exact = true }).ClickAsync();
await page.Locator("#select2-company_id-jn-container").ClickAsync();
await page.Locator("#select2-company_id-jn-container").ClickAsync();
await page.GetByLabel("Select Company").GetByText("Select Company").ClickAsync();
await page.GetByText("Abernathy-Stracke").ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Asset Tag", Exact = true }).ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).ClickAsync();
await page.GetByRole(AriaRole.Textbox, new() { Name = "Serial" }).FillAsync("123456");
await page.Locator("#select2-model_select_id-container").ClickAsync();
await page.GetByText("Laptops - Macbook Pro 13\" (#").ClickAsync();
await page.GetByLabel("Select Status").GetByText("Select Status").ClickAsync();
await page.GetByRole(AriaRole.Option, new() { Name = "Ready to Deploy" }).ClickAsync();
await page.GetByLabel("Select a User").GetByText("Select a User").ClickAsync();
await page.GetByText("Ardith Abbott (schaden.").ClickAsync();
await page.Locator("button[name=\"submit\"]").ClickAsync();
await page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).ClickAsync();
await page.GetByRole(AriaRole.Searchbox, new() { Name = "Search" }).FillAsync("Abbott");
await page.Locator("input[name=\"btSelectItem\"]").Nth(5).CheckAsync();
await page.Locator("#assetsListingTable").GetByRole(AriaRole.Link, new() { Name = "TEST3634458724644" }).ClickAsync();
await page.GetByRole(AriaRole.Link, new() { Name = "History" }).ClickAsync();
await page.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Link, new() { Name = "Admin User" }).ClickAsync();
await page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
