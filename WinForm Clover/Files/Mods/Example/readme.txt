
	Mods?, does it add anything like in those moddable games?, no, I created this application as a control panel to make things easy for me, it has a alarm feature and a command bar, but I added mods so I can always add or remove new things easily from the application, 
	
	
	to add a mod create a folder inside Mod's folder, and copy "mod.xml" and "info.txt" into your Mod's folder, inside "mod.xml" ignore the desc and change the name, and inside "info.txt" is the description of your mod, description isn't necessary but I putted it there :P
	
	
	after having a folder with "mod.xml" and "info.txt", 
	
		- open visual studio, create a new project
		
		- choose "Class Library (.NET framework)"
		
		- right click References from the Solution Explorer, add "CPLib.dll" from the application's main directory as a reference
		
		- add "using CPLib;" at the top of your class
		
		- click "CPLib" from the References and set "Copy Local" to False from the Properties
		
		- inside your mod folder check for a "CPLib.dll" or "CompAssistLib.dll", if you build with "Copy Local" set to true, those dlls will be copied to your mod's directory, if those dlls are inside your mod folder, delete them 
		
		- from visual studio from the top menu, select "Project" and select your Project's Properties, select "Build", scroll down until you see "Output path", set it to your mod's directory, after build, your mod's.dll should appear inside your mod's directory and should be updated
		
		- create a static class and have a method named "OnLoad" without any parameters
		
				
				public static void OnLoad(){
				
				}
				
			
		- this method is called on application start, in here you can add custom commmands
		
		- use CPCmdBar.RegisterCmd() inside OnLoad()
		
		- check out example.cs.txt / Example.dll
		
		other notes:
		
			- use vars.log() to print it to the log