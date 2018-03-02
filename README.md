# TextFinder
A C# Windows Forms application that conducts a case insensitive search and lists occurences in a ListView control
that will highlight an occurrence when an item has been clicked or prompt user to edit occurrence when an item has been double clicked.

Discovered that the standard ListBox control would not be suitable for multicolumn data, even though it has a MultipleColumns property.
Needed to use a ListView control instead. Had issues with the SelectedIndexChange() event for the ListView since it the SelectedItems 
collection was always null. Ditto for FocusedItem and SelectedIndices properties. I used the Click() method instead, which allows access
to these collections and objects.

Added a toolTip control so that hovering the mouse over some controls will display a tooltip.

The application performs a case insensitive search on the text in the Input box. Each occurrence, along with its starting and 
ending positions, is added to the LisView control, which sorts items in ascending alphabetical order.

When an item in the ListView is clicked the corresponding text in the Input box is highlighted. If the item is double clicked, an
InputBox dialog (borrowed from Visual Basic, which was referenced in the project) prompts the user to update the value.
