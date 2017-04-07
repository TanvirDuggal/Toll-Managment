# Toll-Managment

Toll management is created for the toll booth on highways that collects road tax from passing vehicles. Collecting each vehicle's data and retrieving them on uses is main aim of this project. Apart from storing vehicle records it keeps record of all the employees working and all the booths that are currently active or reactive.

This project is built in VB.net with framework 4.6.1 and SQL-Server as database. Because the project uses "Visual Studio" so it is windows operating system dependent. Although database is used, but the images of vehicle are not stored in it, for not letting the database go overloaded and affecting the performance of the project.

 Structure.... 
 The employee section contains an option to "Add", "Edit", "View" and "Settings".
 The "Add" section lets the user add a new employee to the database, the fields included are "Name", "Address", "City", "State", "Pincode", "Contact No.", "Email ID", "Password", "Employee Types". The admin inputs all the fields and all of them comes under that category of "Required". When you save a new employee, he/she will get their own unique "Employee ID", with Employee ID and password they will be able to access their department of software.
 The "Edit" Section lets you edit the data of a user, select the "Employee ID" and get his info on screen, you change anything except his password, Employee Id and name. 
 The "View" Section lets you access and view all the employees, whether they are working or left.
 The "Setting" section lets you change the password and Employee Type. 
 
 The booth manager section lets you create additional booth on software. Note only 10 booths at a time can function to add a new booth one older booth need to delete.
 Once the booth is created, by default it is "Deactivated" i.e. it is not used to start the usage of booth click on the "Activate" button. The booth can also be "Deactivated" for repairing purpose or any other.
 
 
The transaction section is the main area of working, it is used by booth clerk and booth managers for the transaction purpose.
It has two options "New Transaction" and "Return". 
The "New Transaction" is used to get info of new car passing by, It further contains two options of "One Way" or "Two way". The two ways are applicable for 12 hours return.
After selecting ways enter the "vehicle Type", which are "2/3 wheeler", "Car/Jeep/Var", "LCV", "Truck/Bus", they have different charges, then enter the vehicle No., and get the charges for vehicle, enter the amount paid and get the money to be returned.
Click on Submit and you will get the slip with your details of "Transaction ID", "vehicle No." and "Time IN"
For "Return", enter the "Transaction ID" from the slip, you will, get all "vehicle No.", "vehicle Type", "Time IN", "Time OUT", "Extra Hours" and "Extra Charges"

The "timing" section allots each Employee their "Working shifts" which are "8:00 AM - 4:00 PM", "4:00 PM to 12:00 AM" and "12:00 AM to 8:00 AM", it can viewed and changed at the same time.
The "vehicle Charges" section allow you to view and edit vehicle charges as per vehicle type.
