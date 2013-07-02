PrestaSharp - Simple .NET REST Client for Prestashop
====================================================


Introduction
------------
A simple REST client written in CSharp for the Prestashop API.
PrestaSharp uses the RestSharp library to consume the Prestashop services.


Basic usage
-----------

1. Initiate a client instance:

```
	string BaseUrl = "http://www.myweb.com/api";
	string Account = "ASDLKJOIQWEPROQWUPRPOQPPRQOW";
	string Password = "";
	ManufacturerFactory ManufacturerFactory = new ManufacturerFactory(BaseUrl, Account, Password);
```

2. Perform CRUD actions through the client:

```
	PrestaSharp.Entities.manufacturer Manufacturer = ManufacturerFactory.Get(6);
	Manufacturer.name.value = "Iron Maiden";
	Manufacturer.active = 1;        
	ManufacturerFactory.Add(Manufacturer);
	ManufacturerFactory.Update(Manufacturer);
	ManufacturerFactory.Delete(Manufacturer);
```


Supported resources
-------------------

- Manufacturers


Supported actions
-----------------

- Read
- Create
- Update
- Delete


Roadmap
-------

- Add other resources