using TallyConnector.Core.Models;
using TallyConnector.Services;

TallyService tally = new("http://localhost", 9000);

tally.Setup("http://localhost", 9000);

await tally.CheckAsync();
var LicesneData = await tally.GetLicenseInfoAsync();

Console.WriteLine($"License Type: {LicesneData.PlanName}");
Console.WriteLine($"License Version: {LicesneData.TallyVersion}");
Console.WriteLine($"User Name: {LicesneData.UserName}");

var company = await tally.GetActiveCompanyAsync();
var companies = await tally.GetCompaniesAsync<Company>();
var path = await tally.GetCompaniesinDefaultPathAsync();

Console.WriteLine();

Console.WriteLine($"Active Company: {company.Name}");
Console.WriteLine($"Companies Count: {companies.Count}");
Console.WriteLine($"Companies Path: {path}");

Console.WriteLine();

var MasterStatistics = await tally.GetMasterStatisticsAsync();
MasterStatistics.ForEach(stat =>
{
	Console.WriteLine($"Master Name: {stat.Name}");
	Console.WriteLine($"Master Count: {stat.Count}");
	Console.WriteLine();
});

/// TRANSACTION ///////////////

//await tally.PostGroupAsync(new Group()
//{
//	Name = "Test Group From API"
//});

//(await tally.GetGroupsAsync()).ForEach(group =>
//{
//	Console.WriteLine($"Group Name: {group.Name}");
//	Console.WriteLine($"Group Type: {group.PrimaryGroup}");
//	Console.WriteLine($"Group Parent: {group.Parent}");
//	Console.WriteLine();
//});

//await tally.PostLedgerAsync(new Ledger()
//{
//	Name = "Test Ledger From API",
//	Email = "testledger@example.com",
//	Group = "Test Group From API",
//});

//(await tally.GetLedgersAsync()).ForEach(ledger =>
//{
//	Console.WriteLine($"Ledger Name: {ledger.Name}");
//	Console.WriteLine($"Ledger Email: {ledger.Email}");
//	Console.WriteLine($"Ledger Group: {ledger.Group}");
//	Console.WriteLine();
//});


//// STOCK ///////////////

//await tally.PostStockGroupAsync(new StockGroup()
//{
//	Name = "Test Stock Group By API",
//	Parent = "Primary Stock Group",
//	ParentId = "Primary",
//});

//await tally.PostStockCategoryAsync(new StockCategory()
//{
//	Name = "Test Stock Category By API",
//	Parent = "Primary Stock Category",
//	ParentId = "Primary",
//});

//(await tally.GetStockGroupsAsync()).ForEach(stockGroup =>
//{
//	Console.WriteLine($"Stock Group Name: {stockGroup.Name}");
//	Console.WriteLine($"Stock Group Parent: {stockGroup.Parent}");
//	Console.WriteLine();
//});

//(await tally.GetStockCategoriesAsync()).ForEach(stockCategory =>
//{
//	Console.WriteLine($"Stock Category Name: {stockCategory.Name}");
//	Console.WriteLine($"Stock Category Parent: {stockCategory.Parent}");
//	Console.WriteLine();
//});

//var stockItem = new StockItem()
//{
//	Name = "Test Stock Item 1 From API",
//	BaseUnit = "Nos",
//	StockGroup = "Test Stock Group By API",
//	Category = "Test Stock Category By API",
//	GSTApplicable = "\u0004 Applicable"
//};
//stockItem.OpeningBal = new(stockItem, 50);
//await tally.PostStockItemAsync(stockItem);

//(await tally.GetStockItemsAsync()).ForEach(stockItem =>
//{
//	Console.WriteLine($"Stock Item Name: {stockItem.Name}");
//	Console.WriteLine($"Stock Item Base Unit: {stockItem.BaseUnit}");
//	Console.WriteLine($"Stock Item Group: {stockItem.StockGroup}");
//	Console.WriteLine($"Stock Item Category: {stockItem.Category}");
//	Console.WriteLine($"Stock Item Opening Value: {stockItem.OpeningValue}");
//	Console.WriteLine();
//});


//// VOUCHER ///////////////

//TallyResult tallyResult = await tally.PostVoucherAsync(new Voucher()
//{
//	VoucherType = "Contra",
//	View = VoucherViewType.AccountingVoucherView,
//	Date = new TallyConnector.Core.Converters.XMLConverterHelpers.TallyDate(new DateTime(2025, 04, 02)),
//	Narration = "Test Contra Voucher from API",
//	Ledgers =
//	[
//		new(){ LedgerName = "Test 1", Amount = -1000},
//		new() { LedgerName = "Cash", Amount = 1000 }
//	],
//});


//(await tally.GetVouchersAsync()).ForEach(voucher =>
//{
//	Console.WriteLine($"Voucher Type: {voucher.VoucherType}");
//	Console.WriteLine($"Voucher Number: {voucher.VoucherNumber}");
//	Console.WriteLine($"Voucher Date: {voucher.Date}");
//	Console.WriteLine($"Voucher Effective Date: {voucher.EffectiveDate}");
//	Console.WriteLine($"Voucher View: {voucher.View}");
//	Console.WriteLine();
//});

Console.ReadLine();