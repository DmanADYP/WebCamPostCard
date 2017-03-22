# WebCamPostCard
Generates Post Cards From Web Cams
Synopsis

This application was developed to utilize the web camera and make a small modification to the image and, then either save the image to the page, or Email to a recipient.
Code Example

The Library utilizes 2 main classes located in the Common folder, EmailImage.cs and Save.cs. EmailImage.cs grabs the image from the screen and sends and email with the image as an attachement. The Credentials for the email account can be found in the web.config and need to use a gmail account. Save.cs grabs the image from the screens and writes it out, allowing the user to save the image to their browser.
Tests

Contributors
Alexander Drew Pennetti
Languages Used:
C#
JavaScript
Libraries:
WebCamApplication

Jquery  version 1.12.4.min.js
	https://jquery.com/
Jquery UI version 1.12.1.min.js
	https://jquery.com/
Log4net 
	https://logging.apache.org/log4net/
 WebCamApplication.Tests
Moq  
	https://github.com/moq/moq4

Configuration
Login:

The Login Account checks for the username and password and stores the value to sessions. It is for show and main goal is to grab a username for the user.

Email Account: 
Must be Gmail, the reason for this is because they are the easiest provider that allow you to send email through their system. There is no configuration to modify the SMTP Server or the port. I have provided an account which credentials are held in the web.config. To modify to another google account please alter the web.config in app setting 
<add key="userEmail" value="TestAppAdyp1234@gmail.com"/>
 	 <add key="userPassword" value="MyDogsNameIsMoxie"/>
Your Gmail will need to allow Less Secure Apps
https://support.google.com/accounts/answer/6010255?hl=en
Logging: 
This application utilizes Log4Net which is already configured in the web.config under  <log4net>. To setup correctly please point the log file to an accessible location at the following location for the web.config file <file value="Log.txt" />
Implementation:
The Application was built in C# utilizing the razor engine and the Microsoft framework NET Framework 4.5.2

Tests:
The project utilizes 3 tests. Test 1 mocks httpcontext to test the write to the screen. Test 2 tests the Emailimage class and its output. Test 3 test the login state of session, again mocking httpcontext the application achieve the pass.

The Application has been tested in Chrome and on IIS Express Server 


