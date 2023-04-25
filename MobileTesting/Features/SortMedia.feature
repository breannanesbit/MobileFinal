Feature: Sorting Media into Lists


@tag1
Scenario: Sorting latest media into video, audio, and visual lists
	Given a latest media list with the following items:
		| Id | MediaKey | UserId | DateUpload               | FileName | Likes | CategoryId | Category |
		| 1  | video1   | 1      | 2023-04-20T10:30:00.000Z | null     | null  | 1          | Videos   |
		| 2  | audio1   | 2      | 2023-04-21T14:00:00.000Z | null     | null  | 2          | Audios   |
		| 3  | picture1 | 1      | 2023-04-22T16:45:00.000Z | null     | null  | 3          | Pictures |
	And a user list with the following items:
		| Id | FirstName | LastName | Username  |
		| 1  | John      | Doe      | johndoe   |
		| 2  | Jane      | Smith    | janesmith |
	And empty video, audio, and visual lists
	When sorting the media into the video, audio, and visual lists
	Then the video list should contain the following items:
		| Id | MediaKey                                                       | UserId | DateUpload               | FileName | Likes | CategoryId | Category |
		| 1  | https://mobilemediastorage.blob.core.windows.net/videos/video1 | 1      | 2023-04-20T10:30:00.000Z | null     | null  | 1          | Videos   |
	And the audio list should contain the following items:
		| Id | MediaKey                                                       | UserId | DateUpload               | FileName | Likes | CategoryId | Category |
		| 2  | https://mobilemediastorage.blob.core.windows.net/audios/audio1 | 2      | 2023-04-21T14:00:00.000Z | null     | null  | 2          | Audios   |
	And the visual list should contain the following items:
		| Id | MediaKey                                                           | UserId | DateUpload               | FileName | Likes | CategoryId | Category |
		| 3  | https://mobilemediastorage.blob.core.windows.net/pictures/picture1 | 1      | 2023-04-22T16:45:00.000Z | null     | null  | 3          | Pictures |

