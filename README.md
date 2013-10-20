PrestaSharp - CSharp .Net client library for the PrestaShop API via web service
====================================================


Introduction
------------
A simple .Net REST client written in C# for the Prestashop API.
PrestaSharp uses the RestSharp library to consume the Prestashop services.


Basic usage
-----------

1) Initiate a client instance:

```
	string BaseUrl = "http://www.myweb.com/api";
	string Account = "ASDLKJOIQWEPROQWUPRPOQPPRQOW";
	string Password = "";
	ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
```

2) Perform CRUD actions through the client:

```
	PrestaSharp.Entities.manufacturer Manufacturer = ManufacturerFactory.Get(6);
	Manufacturer.name = "Iron Maiden";
	Manufacturer.active = 1;        
	ManufacturerFactory.Add(Manufacturer);
	ManufacturerFactory.Update(Manufacturer);
	ManufacturerFactory.Delete(Manufacturer);
```


Supported resources
-------------------

- Manufacturers
- Products
- Categories
- Languages
- Images
- Combinations
- Tags
- Product Options
- Product Option Values
- Stock Availables
- Shops


Supported actions
-----------------

- Create
- Read
- Update
- Delete


Roadmap
-------

- Add other resources
