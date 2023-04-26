# Building The API and App for Production

## API

When you are ready to push the current API to production, follow these steps:

1. Commit your changes, adding something inconsequential if needed. **Do not push to main**.
2. Go to Visual Studio and click the 'Git Changes' tab. Create it if you don't have it visible. There are 5 buttons: two down arrows, one up arrow, 2 rotating arrows, and '...'. Click on '...'.
3. Click 'Manage Branches', which will open up a tab with a map of all the commits and merges. Under 'Outgoing' will be the commit you just made. Right-click on it and select 'New Tag'.
4. Go back to the previous tag in the history starting with a capital 'V', and increment the number by whatever is appropriate. Use that number as the new tag.
5. Push the commit.
6. Click on '...' again, and select 'Push tags to-' and select 'origin'. 
7. Once that is done, the build will commence. If it breaks, then chances are something is broken in the pipeline. Do not do anything with the pipeline unless you know what you're doing and/or have a more senior developer helping.

## App

To push the current app to production:

1. Follow the same steps as for the API, but use a lowercase 'v' instead of a capital 'V' when creating a new tag.
