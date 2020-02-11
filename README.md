# TO DO

- Process the users image
  * Allow the user to resize their image, and display how many stitches (pixels) the image will require
  * Analyse each pixel of the image, and determine the closet colour match of the selected DMC values
  * Store these matches so they can be recalled/displayed on a grid, that the user can use when stitching
  
- User interface
  * When the image is processed, display the matched DMC values in a grid that the user can pan around.
  * Make each stich in the grid selectable, allowing to highlight completed stitches (single click to highlight, double to remove highlight.
  
- Allow exporting the matched DMC grid to pdf form for printing

# Done

- Create windows form application to hold everything in
  * Set the windows form size options, not allowing for resizing.
- Added a check list containg all DMC values, along with a palette count display to show how many DMC values are selected
  * This is used by the used to select the values they want to use when converting the image
- Added a load image button, that loads a preview of the users image to an image box
- Added a convert button that will start the process of converting the users image
