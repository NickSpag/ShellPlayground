# Shell Playground
A Xamarin.Forms app using Shell navigation that serves as a playground for testing things out.


## Sticky Header in ScrollView

In the [ScrollPage.xaml](https://github.com/NickSpag/ShellPlayground/blob/master/source/ShellPlayground/Views/ScrollPage.xaml) and its code-behind [Scrollpage.xaml.cs](https://github.com/NickSpag/ShellPlayground/blob/master/source/ShellPlayground/Views/ScrollPage.xaml.cs) we enable a parallax-like effect of a label that sticks to the top of the visible page.

Using a grid, we place a Label over the contents of a scroll view. The label should sit over the top of the image at the beginning of the scroll view. When the image first loads, we calculate its height, subtract the height of our label, and that difference becomes the top margin of the label, and a guideline point. Separately, we listen for any changes to the scroll view's vertical scroll position. As it's scrolled, we move the header along with it, unless it's less than the top guideline value we saved earler, in which we just leave it positioned at that point. 