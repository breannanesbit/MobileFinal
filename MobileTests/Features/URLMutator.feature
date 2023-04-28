Feature: MutationUrl function

Scenario: Mutate media URL based on category ID
Given a media with ID 1, media key "test.mp4", and category ID 1
When the MutationUrl function is called on the media
Then the media key should be "https://mobilemediastorage.blob.core.windows.net/videos/test.mp4"

Scenario: Mutate media URL for audio category
Given a media with ID 2, media key "test.mp3", and category ID 2
When the MutationUrl function is called on the media
Then the media key should be "https://mobilemediastorage.blob.core.windows.net/audios/test.mp3"

Scenario: Mutate media URL for picture category
Given a media with ID 3, media key "test.jpg", and category ID 3
When the MutationUrl function is called on the media
Then the media key should be "https://mobilemediastorage.blob.core.windows.net/pictures/test.jpg"

Scenario: Handle unexpected category
Given a media with ID 4, media key "test.unknown", and category ID 4
When the MutationUrl function is called on the media
Then the media key should be "test.unknown"




