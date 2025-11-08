# Deathcard Generator

## Setup

1. Install the latest release.
2. Extract it to a folder, than within that folder do the following.
3. Create a folder called `Cards`.
4. Within that folder create 3 folders; `Exports`, `AssembledPortraits`, `Portrait Peices`
5. Within `Portrait Peices` create 3 subfolders; `Eyes`, `Heads`, `Portraits`.
6. Place one `114x94` image in each, and specifically within Heads make one start with `M-`, `F-`, `N-`, this is so that lists do not break in the code.
7. Go back up to `Cards`, create 2 files, `Names.txt`, and `Genders.txt`.

## How to Utilize

1. Within `Names.txt`, fill this out with all of the names for the deathcards you wish to generate, each name should be on a new line, and additionally no white space or commas should be at the end of the card as if they are they will be put in the generated name.
2. Within `Genders.txt` in the exact order of the Names fill it out with `F`, `M`, and `N` values. `F` = Feminine, `M` = Masculine, `N` = Neuter, these are used to ensure the portrait matches the gender your name is of.
3. In Portrait Peices -> Heads, put all of the head bases you want to use make sure their labled with the gender in the style of `Letter-Head-Num` or `Letter-Name`.
4. In Portrait Peices -> Eyes, put all the eyes you want to use.
5. In Portrait Peices -> Mouths, put all the mouths you want to use.
6. Run the Executable.

## How should the portrait peices be setup?

* Each peice should be exactly 114x94.
* Each head base should have a hole for the eyes and the mouths, usually something like a bar should work.
* Each Eye and Mouth should be the exact size of the created hole with a +1 to the left and right, and also at the exact position of the hole, this is because they are pasted atop the base which means if theres no black space in the mouth or eyes there will be transparency, though I suppose it depends on your head base setup but if its like base game than yes the black strip with a mouth or eye within is needed.

## Where can I get support with this?

* Ask over in Fanscryption's Discord or Reddit and I should see it.