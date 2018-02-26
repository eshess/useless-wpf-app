# Useless WPF App

This was created to assist in a joke at a company party. I've scrubbed it of IP and replaced employee names with others. While the project itself is useless and pure presentation, I took the opportunity to familiarize myself better with WPF. There were a few things I had trouble with and wish to be able to reference in more useful projects down the road.

## Points of Interest

Feel free to critique how I did a thing. Note that the UI was made obnoxiously large so it could be read from a distance.

### /Assets/AppResources.xaml

* The window style templates needed to create a functional custom window.

### BackdropWindow.xaml.cs

* Line two of MatrixPeek_Completed. I was trying to progromattically aquire the location to spin up new windows that would fill the space of the rectangle animations I was creating. This came close but I never quite got it.

### Prompt.xaml and Warning.xaml

* Combination of setting SizeToContent on the Window and using an AccessText object with word wrapping to create custom message boxes that size according to content.

## Built With

* [VisualStudio](http://www.visualstudio.com/)

## Authors

* **Eli Hess** - *Initial work* - [Eli Hess](https://github.com/eshess)

## Acknowledgments

* StackOverflow for the many many times I referened other people's questions
* The internet for providing me with random imagery and sound bytes to assist in telling a joke
* WpfAnimatedGif for making gif images so easy to incorporate
