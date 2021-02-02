# PrestaSharp

[![Build Status](https://travis-ci.org/Bukimedia/PrestaSharp.svg?branch=master)](https://travis-ci.org/Bukimedia/PrestaSharp)
[![Total alerts](https://img.shields.io/lgtm/alerts/g/Bukimedia/PrestaSharp.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/Bukimedia/PrestaSharp/alerts/)
[![Language grade: C#](https://img.shields.io/lgtm/grade/csharp/g/Bukimedia/PrestaSharp.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/Bukimedia/PrestaSharp/context:csharp)

### CSharp .Net client library for the PrestaShop API via web service

## Introduction
A simple .Net REST client written in C# for the Prestashop API.
PrestaSharp uses the RestSharp library to consume the Prestashop services.

# Installation

[![NuGet](https://buildstats.info/nuget/PrestaSharp)](http://www.nuget.org/packages/PrestaSharp)

PrestaSharp is [available on NuGet](https://www.nuget.org/packages/PrestaSharp/). Use the package manager
console to install it:

```powershell
Install-Package PrestaSharp
```

## Basic usage
1) Initiate a client instance:

```csharp
string baseUrl = "http://www.myweb.com/api";
string account = "ASDLKJOIQWEPROQWUPRPOQPPRQOW";
string password = "";

ManufacturerFactory manufacturerFactory = new ManufacturerFactory(baseUrl, account, password);
```

2) Perform CRUD actions through the client:

```csharp
Bukimedia.PrestaSharp.Entities.manufacturer manufacturer = manufacturerFactory.Get(6);
manufacturer.name = "Iron Maiden";
manufacturer.active = 1;
manufacturerFactory.Add(manufacturer);
manufacturerFactory.Update(manufacturer);
manufacturerFactory.Delete(manufacturer);
```

3) Add an image:

```csharp
Bukimedia.PrestaSharp.Entities.product myProduct = new Bukimedia.PrestaSharp.Entities.product();
ProductFactory productFactory = new ProductFactory(baseUrl, account, password);
myProduct = productFactory.Add(myProduct);
ImageFactory imageFactory = new ImageFactory(baseUrl, account, password);
imageFactory.AddProductImage((long)myProduct.id, "C:\\MyImage.jpg");
```

4) Set quantity of products:
The quantity of a product may not be updated directly in the 'product' entity. You need to update 'stock_available' entity.

```csharp
StockAvailableFactory stockAvailableFactory = new StockAvailableFactory(baseUrl, account, password);
long stockAvailableId = myProduct.associations.stock_availables[0].id;
Bukimedia.PrestaSharp.Entities.stock_available myStockAvailable = stockAvailableFactory.Get(stockAvailableId);
myStockAvailable.quantity = 99; // Number of available products
myStockAvailable.out_of_stock = 1; // Must enable orders
stockAvailableFactory.Update(myStockAvailable);
```

## Advanced usage
1) Get all. This sample retrieves the list of manufacturers:

```csharp
List<manufacturer> manufacturers = ManufacturerFactory.GetAll();
```

2) Get ids. This sample retrieves the list of the manufacturer ids:

```csharp
List<long> ids = ManufacturerFactory.GetIds();
```

3) Get by filter. This sample retrieves the list of manufacturers which name is "Metallica":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "Metallica");
List<manufacturer> manufacturers = ManufacturerFactory.GetByFilter(dtn, null, null);
```

4) Get by filter with wildcards. This sample retrieves the manufacturers which name starts with "Metall":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "[Metall]%");
List<manufacturer> manufacturers = ManufacturerFactory.GetByFilter(dtn, null, null);
```

5) Get ids by filter. This sample retrieves the list of the manufacturers ids which name is "Metallica":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "Metallica");
List<long> ids = ManufacturerFactory.GetIdsByFilter(dtn, null, null);
```

6) Get ids by filter with wildcards. This sample retrieves the list of the manufacturers ids which name starts with "Metall":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "[Metall]%");
List<long> ids = ManufacturerFactory.GetIdsByFilter(dtn, null, null);
```

7) Get by complex filter. This sample retrieves the top five manufacturers in ascendent sorting which name starts with "Metall":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "[Metall]%");
List<manufacturer> manufacturers = ManufacturerFactory.GetByFilter(dtn, "name_ASC", "5");
```

8) Get by filter for pagination. This sample retrieves the top five manufacturers from tenth position in ascendent sorting which name starts with "Metall":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "[Metall]%");
List<manufacturer> manufacturers = ManufacturerFactory.GetByFilter(dtn, "name_ASC", "[9,5]");
```

9) Get ids by filter. This sample retrieves the list of the manufacturers ids which name is "Metallica", "Nirvana" or "Pantera":

```csharp
Dictionary<string, string> dtn = new Dictionary<string, string>();
dtn.Add("name", "[Metallica|Nirvana|Pantera]");
List<long> ids = ManufacturerFactory.GetIdsByFilter(dtn, null, null);
```

10) Get by filter by range date. This sample retrieves the orders in a date range:

```csharp
DateTime startDate = new DateTime (2016, 1, 1);
DateTime endDate = new DateTime (2016, 1, 31);
Dictionary<string, string> filter = new Dictionary<string, string>();
string dFrom = string.Format("{0:yyyy-MM-dd HH:mm:ss}", startDate);
string dTo = string.Format("{0:yyyy-MM-dd HH:mm:ss}", endDate);
filter.Add("date_add", "[" + dFrom + "," + dTo + "]");
List<long> prestaSharpOrderIds = this.OrderFactory.GetIdsByFilter(filter, "id_DESC", null);
```

## Supported resources
- Address
- Carriers
- Carts
- Categories
- Combinations
- Currencies
- Customers
- Customer Messages
- Customer Threads
- Guests
- Groups
- Images
- Languages
- Manufacturers
- Messages
- Orders
- Order Carriers
- Order Cart Rules
- Order Histories
- Order Invoices
- Order States
- Products
- Product Features
- Product Feature Values
- Product Options
- Product Option Values
- Product Suppliers
- Shops
- Specific Prices
- Specific Price Rules
- States
- Stock Availables
- Tags
- Tax
- Tax Rule
- Tax Rule Groups
- Warehouse
- Zones

## Supported actions
- Create
- Read
- Update
- Delete

## Roadmap
- Add other resources

## Debugging

Enabling debugging in PrestaShop would make PrestaSharp exceptions more verbose, to enable that, edit ```/config/defines.inc.php``` file in your PrestaShop website and edit this code block:

```php
define('_PS_MODE_DEV_', false);
```

to:

```php
define('_PS_MODE_DEV_', true);
```

More information in the development section of [PrestaShop's documentation](http://doc.prestashop.com/display/PS15/Setting+up+your+local+development+environment).

## Help & Discussion

If your problem is how to implement anything with PrestaSharp or make a question,
please, refer to our Slack group: 
[PrestaSharp Slack Group](https://join.slack.com/t/prestasharp/shared_invite/enQtNTM2OTI1OTg0NzUyLTY4NDdkZDFmY2EwMGE4MTMzZjk5YzZiMTk3MzUwNzUxNTdhMWEwZjFjNDJiZTIyMjI0MDM0NTcwMzIzNGI0Njc)

## License
PrestaSharp is GNU General Public License (GPL)

This program is distributed in the hope that it will be useful, but without any warranty; without even the implied warranty of merchantabilty or fitness for a particular purpose. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.

Bukimedia reserves the right to mention of companies or individuals who use this software.

Copyright (C) 2019 Bukimedia
- Bukimedia: https://bukimedia.com/
- Twitter: http://twitter.com/bukimedia
- GitHub: https://github.com/bukimedia
- PrestaSharp on Bukimedia: https://bukimedia.com/prestasharp/
