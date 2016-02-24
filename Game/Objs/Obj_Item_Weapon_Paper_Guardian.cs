// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Guardian : Obj_Item_Weapon_Paper {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.info = @"<b>A list of Holoparasite Types</b><br>

 <br>
 <b>Chaos</b>: Ignites enemies on touch and teleports them at random on attack. Automatically extinguishes the user if they catch on fire.<br>
 <br>
 <b>Standard</b>:Devastating close combat attacks and high damage resist. Can smash through weak walls.<br>
 <br>
 <b>Ranged</b>: Has two modes. Ranged; which fires a constant stream of weak, armor-ignoring projectiles. Scout; Cannot attack, but can move through walls and is quite hard to see. Can lay surveillance snares, which alert it when crossed, in either mode.<br>
 <br>
 <b>Support</b>:Has two modes. Combat; Medium power attacks and damage resist. Healer; Heals instead of attack, but has low damage resist and slow movement. Can deploy a bluespace beacon and warp targets to it (including you) in either mode.<br>
 <br>
 <b>Explosive</b>: High damage resist and medium power attack. Can turn any object, including objects too large to pick up, into a bomb, dealing explosive damage to the next person to touch it. The object will return to normal after the trap is triggered or after a delay.<br>
";
			this.icon_state = "paper_words";
		}

		public Obj_Item_Weapon_Paper_Guardian ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			return false;
		}

	}

}