Synopsis

This application was developed to to utilize the web camera and make a small modifications to the image and then either save the image to the page or Email to a recipient.
Code Example

The Library utilizes 2 main classes located in the Common folder, EmailImage and Save. Email Image grabs the image from the screen and creates and sends and email. The Credentials for the email account can be found in the webconfig and need to use a gmail account. Save class grabs the image from the screens and writes it out, allowing the user to save the image to their browser.
Motivation


Installation

This project was developed to run on .NET Framework 4.5.2 using the razor engine and was developed using the MVC framework.

The project can run on any server meeting the above criteria.


Tests

The project utilizes 3 test. Test 1 mocks httpcontext to test the write to the screen. Test 2 tests the Emailimage class and its output. Test 3 test the login state of session, again mocking httpcontext the achieve the pass.

Contributors

Alexander Drew Pennetti
