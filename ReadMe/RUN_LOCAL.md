# How to run the app locally


1. Turn on Dev Tunnels. If you don't know how to do this, go to https://learn.microsoft.com/en-us/aspnet/core/test/dev-tunnels?view=aspnetcore-7.0
2. Select MediaApi as the project to run
3. Where the green triangle button is to run the program, there is a dropdown menu. Click it, and select Dev Tunnels, right below Script Debugging. If this does not appear, close Visual Studio and reopen it.
4. Create a persistent tunnel, following the prompts
5. Run the API, and copy the url before the swagger endpoint
6. At roughly line 30 in MobileFinal/MauiProgram.cs, you will see 2 HTTPClient declarations. On both of them, comment out the line defining the URI as being to azure
7. Copy the lines, and paste them below the commented line. In place of the old URI, use the URL from the local run of the API, removing the swagger endpoint from this URL beforehand
8. End the current run of the API
9. Set up the project to run the app and the API at the same time
10. Run the two projects