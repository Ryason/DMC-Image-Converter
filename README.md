### [Latest Release](https://ryason.github.io/DMC-Converter.html)
---
### About
DMC Image Converter is a tool used to create cross stitch patterns from images.

### How To Use
> Load an image into the application by clicking the Load Image button.

> Controll the size of your cross stich pattern by setting the width, with the width controll box.

> Select from the list of DMC values, which floss' you would like to use with your pattern.

> Pressing the convert button will start the image conversion, and will result in the pattern being displayed on a large grid.

> You can any grid cell to make the cell white, temporarily, if the DMC value in the cell is hard to read.

> Once you have completed a stitch, double click on the cell to mark it red.

### Current Features
- Load an image and have it converted into a pattern for cross stitching with DMC floss
- Resize a loaded image to a set width.
- Create a palette of DMC floss colours, that will be used in converting a loaded image.
- Display grid showing DMC values, representing the converted pixels of the loaded image.
- Double click a grid cell to mark it as stitched.
- Double click a marked cell to unmark it, if if was marked by mistake.
- Select between different colour matching algorithms. Each gives a slightly different result. With the closeest current algorithm being [CIE2000](https://en.wikipedia.org/wiki/Color_difference#CIELAB_%CE%94E*). Although the closest mathematically, you may want to play around with what the other versions produce.
---
### Features I Would Like To Add
- Save and load previous conversions. As well as saving and loading of marked grid cells, to keep a users stitching progress.
- Bigger floss selection. Such as brands of floss other than DMC.
- Ability to see what the floss colours look like next to the selection panel.
- Track how long a user has been stitching a pattern, and estimate a completion date.
- Display what coloured floss is actually in the converted image, as the entire palette may not be used. Just because a colour has been selected, certain colours may never be matched to pixels in the users image.
- Track each colour floss and the amount required. With a display showing how many stitches of that colour are left to stitch in the image.
- Ability to save a converted iamage pattern to pdf in order to print it out.
- Update button that links to this project's repo, so users can get the latest version. (Could store version number in code and check against current release version number. Then alert if users exe is not the latest)
- Option to paint your own pattern using a pallet selector and drawing(clicking) directly on the grid.
- Go public...
