# Mandag d. 31/5-21

	* Created ER-overview

	# Basemodel
		*	Id - int
		•	CreatedAt - datetime
		•	UpdatedAt - datetime
		•	DeletedAt - datetime
	# Login
		•	Id - int
		•	Email - char
		•	Password - char
		•	Firstname - char
		•	Lastname - char
		•	Role - int
	# Address
		•	Login.Id (FK - Login) 
		•	Street - char
		•	House - char
		•	City - char
		•	Zip Code - int
		•	Country - char
	# Order
		•	Id - int
		•	Login.Id - int (FK - Login)
		•	Date - datatime
	# Order.Details
		•	Order.Id - int (FK - Order)
		•	Product.Id - int (FK - Product)
		•	Quantity - int
		•	Price - float
	# Category
		•	Id - int
		•	Name - char
	# Product
		•	Id - int
		•	Name - char
		•	Brand.Id - int (FK - Brand)
		•	Category.Id - int (FK - Product)
		•	Price - float
		•	Quntity - int
	# Brand
		•	Id - int
		•	Name - char
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
					-	<List<OrderDetail>>  GetAll()
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
			* IBrand
					-	<List<Brand>> GetAll()
					-	<Brand> GetById(int id)
					-	<Brand> Create(Brand brand)
					-	<Brand> Update(int id, Brand brand)
					-	<Brand> Delete(int id)

	#TODO

		- Create rest interfaces repos
		- Create corresponding class repos

		- setup database (dbContext, connectionstring etc.)