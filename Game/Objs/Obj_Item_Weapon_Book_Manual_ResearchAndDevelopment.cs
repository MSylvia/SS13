// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Book_Manual_ResearchAndDevelopment : Obj_Item_Weapon_Book_Manual {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.author = "Dr. L. Ight";
			this.title = "Research and Development 101";
			this.dat = @"<html>
				<head>
				<style>
				h1 {font-size: 18px; margin: 15px 0px 5px;}
				h2 {font-size: 15px; margin: 15px 0px 5px;}
				li {margin: 2px 0px 2px 15px;}
				ul {list-style: none; margin: 5px; padding: 0px;}
				ol {margin: 5px; padding: 0px 15px;}
				</style>
				</head>
				<body>

				<h1>Science For Dummies</h1>
				So you want to further SCIENCE? Good man/woman/thing! However, SCIENCE is a complicated process even though it's quite easy. For the most part, it's a three step process:
				<ol>
					<li> 1) Deconstruct items in the Destructive Analyzer to advance technology or improve the design.</li>
					<li> 2) Build unlocked designs in the Protolathe and Circuit Imprinter</li>
					<li> 3) Repeat!</li>
				</ol>

				Those are the basic steps to furthing science. What do you do science with, however? Well, you have four major tools: R&D Console, the Destructive Analyzer, the Protolathe, and the Circuit Imprinter.

				<h2>The R&D Console</h2>
				The R&D console is the cornerstone of any research lab. It is the central system from which the Destructive Analyzer, Protolathe, and Circuit Imprinter (your R&D systems) are controled. More on those systems in their own sections. On its own, the R&D console acts as a database for all your technological gains and new devices you discover. So long as the R&D console remains intact, you'll retain all that SCIENCE you've discovered. Protect it though, because if it gets damaged, you'll lose your data! In addition to this important purpose, the R&D console has a disk menu that lets you transfer data from the database onto disk or from the disk into the database. It also has a settings menu that lets you re-sync with nearby R&D devices (if they've become disconnected), lock the console from the unworthy, upload the data to all other R&D consoles in the network (all R&D consoles are networked by default), connect/disconnect from the network, and purge all data from the database.
				<b>NOTE:</b> The technology list screen, circuit imprinter, and protolathe menus are accessible by non-scientists. This is intended to allow 'public' systems for the plebians to utilize some new devices.

				<h2>Destructive Analyzer</h2>
				This is the source of all technology. Whenever you put a handheld object in it, it analyzes it and determines what sort of technological advancements you can discover from it. If the technology of the object is equal or higher then your current knowledge, you can destroy the object to further those sciences. Some devices (notably, some devices made from the protolathe and circuit imprinter) aren't 100% reliable when you first discover them. If these devices break down, you can put them into the Destructive Analyzer and improve their reliability rather then futher science. If their reliability is high enough ,it'll also advance their related technologies.

				<h2>Circuit Imprinter</h2>
				This machine, along with the Protolathe, is used to actually produce new devices. The Circuit Imprinter takes glass and various chemicals (depends on the design) to produce new circuit boards to build new machines or computers. It can even be used to print AI modules.

				<h2>Protolathe</h2>
				This machine is an advanced form of the Autolathe that produce non-circuit designs. Unlike the Autolathe, it can use processed metal, glass, solid plasma, silver, gold, and diamonds along with a variety of chemicals to produce devices. The downside is that, again, not all devices you make are 100% reliable when you first discover them.

				<h1>Reliability and You</h1>
				As it has been stated, many devices when they're first discovered do not have a 100% reliablity when you first discover them. Instead, the reliablity of the device is dependent upon a base reliability value, whatever improvements to the design you've discovered through the Destructive Analyzer, and any advancements you've made with the device's source technologies. To be able to improve the reliability of a device, you have to use the device until it breaks beyond repair. Once that happens, you can analyze it in a Destructive Analyzer. Once the device reachs a certain minimum reliability, you'll gain tech advancements from it.

				<h1>Building a Better Machine</h1>
				Many machines produces from circuit boards and inserted into a machine frame require a variety of parts to construct. These are parts like capacitors, batteries, matter bins, and so forth. As your knowledge of science improves, more advanced versions are unlocked. If you use these parts when constructing something, its attributes may be improved. For example, if you use an advanced matter bin when constructing an autolathe (rather then a regular one), it'll hold more materials. Experiment around with stock parts of various qualities to see how they affect the end results! Be warned, however: Tier 3 and higher stock parts don't have 100% reliability and their low reliability may affect the reliability of the end machine.
				</body>
				</html>
			";
			this.icon_state = "rdbook";
		}

		public Obj_Item_Weapon_Book_Manual_ResearchAndDevelopment ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}