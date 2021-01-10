# ALPLen

### Version
v1.0
### Description (Purpose)
A stand-alone Windows Presentation Foundation (WPF) application that calculates required minimal pile length considering ultimate limit state (ULS) compressive resistance of single axially loaded concrete pile according to Eurocode EN 1997-1, 7.6.2.3 *Ultimate compressive resistance from ground test results*, and using ground data from Cone Penetration Test (CPT) results according to EN 1997-2, Annex D *Cone and piezocone penetration tests*.
### Source code
Written in C# and XAML. Target framework: .NET Core 3.1. Due to small scope and complexity of the application its architecture does not strictly follows any particular design pattern, yet to some extent ideas from traditional WPF design patern Model-View-ViewModel (MVVM) were borrowed and implemented. Whole source code is provided in this repository.
### Installation
At this stage (v1.0) the project executable (.exe) file and all other required files are compiled and provided via this repository. To start using this application all is needed is to download ALPLen_v1.0.rar file, extract it to your preferred location in your storage, and run ALPLen.exe file on your system. ALPLen v1.0 only uses internal resources of its source code. It does not require internet connection - works offline.
### Usage
The program is intended for professional usage, yet it is not complicated and follows very simple structure to achieve desired results. Nonetheless, it is assumed that users have basic knowledge of the pile design approach mentioned in the description and will be able to find all additional data and information if needed on his own.

Following paragraphs will describe user interface (UI) and will provide basic descriptions of inputs, outputs, and functionality implemented in v1.0.

Once you have downloaded ALPLen.exe and ran it you will see main app window pop up.

In the top part of the main window there is a menu bar with two menus named - **File**, **Help**. In v1.0 the only working item in **File** menu is **Exit** which basically closes the app. Selecting **Help** menu item **View documentation** will open URL to this .md document. 

Main window has three tabs:
* Inputs (inputs for general pile design parameters)
* Ground Data (inputs and data for pile positioning and ground characteristics from CPT test results)
* Results (output summary)

The app is controlled using available buttons in each tab. There are multiple input boxes, tables and windows of which data are used in the main computation operation and outputing results.

The app main window has two section: the left one contains inputs, control units; the right one - static 2D images for visualizing some of required inputs for clarity. Inputs such as various coefficients can be found on the literature, research papers, national standards, and other resources related to the problem.

Basic concept of the workflow is to go through each tab consecutively, fill or edit required inputs it the first two tabs and review results in the last one. At any stage of this process user can get back and change inputs. The results we will be update after pressing Calculate button in the Ground Data tab or after selecting Results tab.

Inputs (by default, input is required if not noted overwise; decimal separator - decimal point (".")):
* Project Information (button) - click this button to add additional information about your project (not required).
* Design Approaches and Coefficient Combinations (table) - default design approaches and coefficient combinations are provided according to EN 1997-1, Annex A. Using button Add you can insert your own customized entry. There can't be empty parameters, except for Comment. Also, you can delete selected entry by pushing Delete Selected button. Order of the table entries is not important.
* Resistance Efficiency Factor - ratio between total acting design load and pile compressive resistance (ULS), in other words, determines "safety" factor for calculation results. Can be typed in the TextBox or set by the slider.
* Ø - pile diameter in meters.
* α<sub>p</sub> - coefficient from EN 1997-2, D.5 table.
* S - coefficient calculated according to EN 1997-2, D.7 chapter.
* β - coefficient calculated according to EN 1997-2, D.7 chapter.
* N<sub>k</sub> - characteristical axial compressive permanent load.
* Q<sub>k</sub> - characteristical axial compressive variable load.
* ξ<sub>3</sub> or ξ<sub>4</sub> - correlation coefficients from EN 1997-1, Annex A. Only one of them can be used. Select appropriate CheckBox and type in the value in the TextBox next to the coefficient symbol.
* Next (button) - moves user to the next Ground Data tab.
* l1 - minimal pile embedment into foundation in meters (self-explanatory parameter)
* l2 - unevaluated depth of ground from surface in meters (self-explanatory parameter)
* l3 - minimal pile embedment into base layer in meters (self-explanatory parameter)
* l4 - minimal ground layer depth under pile base in meters (self-explanatory parameter)
* Ground layers (table) - empty by default. To add new entries to the table use Add button. In addition, you can delete selected entry using Delete Selected button or clear all entries using Clear All button. There can't be empty parameters, except for Id, Name, and Comment. The last (bottom) entry in the table will be considered as the base layer. Make sure you input ground layers from top to bottom accordingly to your CPT test results. The order of the table entries is very important! User can manipulate this order by using up and down arrow keys next to each entry.
* Back (button) - moves user to the previous Inputs tab.
* Calculate (button) - performs computations and moves user to the next Results tab.

The app will fail to calculate correct results and provide output if not all necessary inputs are given or they are typed incorrectly. In this case, it will show user a simple MessageBox with error code: *UserInputError. Check your inputs and try to calculate again*.

If there is no possible solution (i.e., required pile compressive resistance can't be achieved in provided conditions, pile minimal length can't be determined), the app will show user a MessageBox with error code: *CalculationError. Can't determine minimal pile length. Please check and/or adjust design parameters, conditions and try again*. This error means that you need to change design general parameters or/and update ground data so that required pile compressive resistance could be achieved in provided conditions.

### Literature
* Eurocode EN 1997-1
* Eurocode EN 1997-2

### Future roadmap (functions to be implemented)
* Improve error checking and feedback to user.
* Add 3D models instead of 2D images for better visualizations.
* Add print feature for formatted result outputs.
* Add option to save a file with current session parameters for later use via the load file function.
* Add hints and reference tables to different parameters.
* Use calcation results to create a 3D pile model using 3D modelling software APIs.

### License
GNU General Public License v3.0
