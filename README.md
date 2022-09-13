# selenium-CSharp-AutomationSuite
Selenium-CSharp-AutomationSuite

DemoWeb Site :https://demowebshop.tricentis.com

> Steps to Setup the Framework
>> - Clone the project.
>> - Install Nugets packages.
>> - Open Test Manager.
>> - Run the tests.

# High Risk Scenarios

>Scenario 1:
>> - Given a user enters valid credentials
>> - And added items to cart
>> - And checkedout
>> - When Billing address and other details set
>> - Then validate Total and Confirm the checkout

>Scenario 2:
>> - Given user enters valid credentials
>> - When user adds the items to cart
>> - Then user should see the count in Shoppingcart menu
>> - And Sub-Total should be sum of the items

> Scenario 3:
>> - Given user adds items to cart 
>> - When Items quantity increased 
>> - Then user should get right amount in Subtotal and Total (*price x quantity*)

> Scenario 4:
>> - Given user adds items to cart 
>> - And check out
>> - Then user should be able to register and checkout

> Scenario 5:
>> - User login with valid credentials
>> - Then user can check their order details 

# Scenarios Automated

Scenario's 1 and 2 are automated. As a user, I would want to add items to cart, securely checkout the order and monitor the status of my order.
