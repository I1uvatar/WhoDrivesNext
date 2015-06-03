# WhoDrivesNext

WhoDrivesNext is meant to be a mobile application to keep track of drives in a car pool. 
Members in the car pool drive to work, taking turns. The main purpose of the application is to keep track who drives and whose turn is it to drive next, by using the fairest system as possible.

### Application development
I will pursue a step by step development process taking tiny steps to implement the application. The main steps I thought about taking are:
* Developing a console client application to satisfy the basic requirements of the application.
* Refactoring the console client with the purpose to extract generic classes and create the basic CORE upon any type of client can be build.
* Developing an Android application with the use of the CORE library from the previous step

### Framework used

For implementation I plan to use the following framework:
* .NET framework
* Xamarin for Android
* Entity framework with SQLite database

Tools used:
* Visual studio 2013/14
* Android emulators

###Current state of development
The console client is built.  
The application currently doesn’t persist state to a file or database, so objects are only alive while the application is running.  

###Latest build
You can find the latest build of the console client (zip containing the executable and pdb file) [here](https://github.com/I1uvatar/WhoDrivesNext/raw/master/build/current/current.zip)

###TODO
* Refactoring the console client to extract the core classes that can be used in any type of client
* Add persistency with using SQLite and Entity framework 
* Add Unit tests
* Add build automation
* Add Android project

###Contributions
All kind of help is welcome.  
You can contribute to the code with opening a pull request.  
I will check every pull request and add it to the branch if the changes are appropriate.  
Later in the time I plan to take use of the GitHub Issue system, so you can make your contributions regarding a certain issue or open a new one.

###Contributions
All kind of help is welcome.  
You can contribute to the code with opening a pull request.  
I will check every pull request and add it to the branch if the changes are appropriate.  
Later in the time I plan to take use of the GitHub Issue system, so you can make your contributions regarding a certain issue or open a new one.

###Donations
All donations are greatly appreciated. The donations will go towards Google Play membership fee.  
You can make a donation via PayPal [here](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=F8UN2XV4LFEX6).  
I will list all the donators on a special page and in the application about screen.
Thanks for all the support!
