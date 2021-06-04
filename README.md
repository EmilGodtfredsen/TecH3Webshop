# Fredag d.4/6-21
	#TODO mandag d.7/6-21
		- Add description attribute for product entity


	* Set Login.Email as unique constraint
	* Created controllers for product, brand and category

# Torsdag d.3/6-21
	#TODO fredag d.4/6-21
		- Make email unique on login entity
		- Create controllers for product, brand and category
		- Display categories and products in client

	* On client installed react-router: npm install --save react-router
	* On client installed react-bootstrap: npm install react-bootstrap bootstrap@4.6.0
	* On client installed fontawesome: 
		- npm i --save @fortawesome/fontawesome-svg-core
		- npm install --save @fortawesome/free-solid-svg-icons
		- npm install --save @fortawesome/react-fontawesome
		- npm install --save @fortawesome/free-brands-svg-icons
		- npm install --save @fortawesome/free-regular-svg-icons
	* On client installed axios: npm install --save axios

# Onsdag d.2/6-21
	#TODO torsdag d.3/6-21
		
		- Finish tests for login service 1 hour
		- Create controllers for all entities
			- If time start up controller test

	* Created rest repository interfaces and specific implementation of interfaces in repos
	* Created Test project, added project reference to .Api from .Tests
	* Implemented validation for email on login repo
	* Implemented validation for minimum length of 6 chars on password, login repo
	* Create if services and implemented services
	

# Tirsdag d.1/6-21
	#TODO onsdag d. 2/6-21

		- Create repositories for Category, Product, Order and OrderDetail.
		- Implement some repository tests

	* Completed setup db with context
	* connectionstring setup inside appsettings.json
	* Modified login repository with GetByEmail method
	* Created address repository
	* Created brand repository


# Mandag d. 31/5-21
	#TODO tirsdag d.1/6-21

		- Create rest interfaces repos
		- Create corresponding class repos
		- setup database (dbContext, connectionstring etc.)

	* Created ER-overviews

	# Basemodel
		*	Id - int
		�	CreatedAt - datetime
		�	UpdatedAt - datetime
		�	DeletedAt - datetime
	# Login
		�	Id - int
		�	Email - char
		�	Password - char
		�	Firstname - char
		�	Lastname - char
		�	Role - int
	# Address
		�	Login.Id (FK - Login) 
		�	Street - char
		�	House - char
		�	City - char
		�	Zip Code - int
		�	Country - char
	# Order
		�	Id - int
		�	Login.Id - int (FK - Login)
		�	Date - datatime
	# Order.Details
		�	Order.Id - int (FK - Order)
		�	Product.Id - int (FK - Product)
		�	Quantity - int
		�	Price - float
	# Category
		�	Id - int
		�	Name - char
	# Product
		�	Id - int
		�	Name - char
		�	Brand.Id - int (FK - Brand)
		�	Category.Id - int (FK - Product)
		�	Price - float
		�	Quntity - int
	# Brand
		�	Id - int
		�	Name - char
	# Repository overview (interfaces)
			* ILogin
				-	<List<Login>> GetAll()
				-	<Login> GetById(int id)
				-	<Login> Create(Login login)
				-	<Login> Update(int id, Login login)
				-	<Login> Delete(int id)
			* IAddress
			// Id refers to Login.Id
				-	<Address> GetById(int id) 
				-	<Address> Create(ind id, Address address)
				-	<Address> Update(int id, Address address)
				-	<Address> Delete(int id)
			* IOrder
				-	<List<Order>> GetAll()
				-	<Order> Create(Order order)
				-	<Order> Update(int id, Order order)
				-	<Order> Delete(int id)
			* IOrderDetail
					//Id refers to Order.Id
					-	<OrderDetail> GetById(int id)
					-	<OrderDetail> Create(OrderDetail orderDetail)
					-	<OrderDetail> Update(int id, OrderDetail orderDetail)
					-	<OrderDetail> Delete(int id)
			* IProduct
					-	<List<Product>> GetAll()
					-	<Product> GetById(int id)
					-	<Product> Create(Product product)
					-	<Product> Update(int id, Product product)
					-	<Product> Delete(int id)
			* ICategory
					-   <List<Category>> GetAll()
					-	<Category> Create(Category category)
					-	<Category> Update(int id, Category category)
					-	<Category> Delete(int id)
			* IBrand
					-	<List<Brand>> GetAll()
					-	<Brand> GetById(int id)
					-	<Brand> Create(Brand brand)
					-	<Brand> Update(int id, Brand brand)
					-	<Brand> Delete(int id)
