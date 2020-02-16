# TO DO

- Process the users image
  * Store these matches so they can be recalled/displayed on a grid, that the user can use when stitching
    * Grid is here, but save and load of matched image is not.
  
- User interface
  * Make each stich in the grid selectable, allowing to highlight completed stitches (single click to highlight, double to remove highlight.
  
- Allow exporting the matched DMC grid to pdf form for printing

- Add options for different stich manufactures, e.g Anchor

# Done

- Create windows form application to hold everything in
  * Set the windows form size options, not allowing for resizing.
    * This is once again resizable, to allow for a display grid 
- Added a check-list containg all DMC values, along with a palette count display to show how many DMC values are selected
- Added a load image button, that loads a preview of the users image to an image box
- Added a convert button that will start the process of converting the users image
- When the image is processed, display the matched DMC values in a grid that the user can pan around.
- Allow the user to resize their image, and display how many stitches (pixels) the image will require
- Analyse each pixel of the image, and determine the closet colour match of the selected DMC values
