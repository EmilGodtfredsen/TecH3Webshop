# Onsdag d.9/6-21
	#TODO torsdag d.10/6-21
		- Finish adminview with full CRUD on prod, cat, login and view of orders
		- Add Authentication on /api/order [POST]
		- Add Authentication functionality on client

	* Added description attribute for product entity
	* Added first 6 products to home page on client
	* Updated nav with categories instead of seperate component
	* Implemented simple message for succes checkout
	* Started on implementing adminview

# Tirsdag d.8/6-21
	#TODO onsdag d.9/6-21
		- Add description attribute for product entity
		- Create login functionality on client
		- Add Authentication on /api/order [POST]
		- Add Authentication functionality on client

	* Created order controller
	* Created order details controller 
	* Updated services and repos handling master/detail for order/order detail
	* Implemented checkout functionality to client


# Mandag d.7/6-21
	#TODO tirsdag d.8/6-21
		- create order with orderDetails
		- Add description attribute for product entity

	* Implemented react-router-dom, for more responsive behavior on client
	* Implemented add to cart, adds to localstorage
	* Created checkout component on client

# Fredag d.4/6-21
	#TODO mandag d.7/6-21
		- Add description attribute for product entity
		- Display product details in react app
		- Create add to basket func.

	* Set Login.Email as unique constraint
	* Created controllers for product, brand and category
	* On client added react-router-dom: npm install --save react-router-dom
	* Displays Categories and products to each category


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

	* Created ER-overview
