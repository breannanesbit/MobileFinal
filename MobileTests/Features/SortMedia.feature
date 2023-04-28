Feature: Sort Media

Sorting the media into different lists

@tag1
Scenario: Sort latest media into correct categories
    Given a list of categories
    And a list of users
    And a list of latest media
    And empty video, audio and visual lists
    When the latest media is sorted into their respective categories
    Then the video list should only contain media with the category "Videos"
    And the audio list should only contain media with the category "Audios"
    And the visual list should only contain media with the category "Pictures"