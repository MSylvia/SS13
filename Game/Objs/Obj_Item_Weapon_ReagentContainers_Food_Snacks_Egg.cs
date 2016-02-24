// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public int? containsPrize = 0;
		public int amount_grown = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 1 );
			this.cooked_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledegg);
			this.filling_color = "#F0E68C";
			this.icon_state = "egg";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: farm_animals.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.loc is Tile ) {
				this.amount_grown += Rand13.Int( 1, 2 );

				if ( this.amount_grown >= 100 ) {
					this.visible_message( "" + this + " hatches with a quiet cracking sound." );
					new Mob_Living_SimpleAnimal_Chick( GlobalFuncs.get_turf( this ) );
					GlobalVars.SSobj.processing.Remove( this );
					GlobalFuncs.qdel( this );
				}
			} else {
				GlobalVars.SSobj.processing.Remove( this );
			}
			return null;
		}

		// Function from file: easter.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			base.attack_self( (object)(user), (object)(flag), emp );

			if ( Lang13.Bool( this.containsPrize ) ) {
				user.WriteMsg( "<span class='notice'>You unwrap the " + this + " and find a prize inside!</span>" );
				this.dispensePrize( GlobalFuncs.get_turf( user ) );
				this.containsPrize = GlobalVars.FALSE;
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: easter.dm
		public void dispensePrize( dynamic where = null ) {
			dynamic won = null;

			won = Rand13.Pick(new object [] { typeof(Obj_Item_Clothing_Head_Bunnyhead), typeof(Obj_Item_Clothing_Suit_Bunnysuit), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolateegg), typeof(Obj_Item_Toy_Balloon), typeof(Obj_Item_Toy_Gun), typeof(Obj_Item_Toy_Sword), typeof(Obj_Item_Toy_Foamblade), typeof(Obj_Item_Toy_Prize_Ripley), typeof(Obj_Item_Toy_Prize_Honk), typeof(Obj_Item_Toy_Carpplushie), typeof(Obj_Item_Toy_Redbutton), typeof(Obj_Item_Clothing_Head_Collectable_Rabbitears) });
			Lang13.Call( won, where );
			new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolateegg( where );
			return;
		}

		// Function from file: snacks_egg.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic C = null;
			string clr = null;

			
			if ( A is Obj_Item_Toy_Crayon ) {
				C = A;
				clr = C.colourName;

				if ( !new ByTable(new object [] { "blue", "green", "mime", "orange", "purple", "rainbow", "red", "yellow" }).Contains( clr ) ) {
					Task13.User.WriteMsg( "<span class='notice'>" + this + " refuses to take on this colour!</span>" );
					return null;
				}
				Task13.User.WriteMsg( "<span class='notice'>You colour " + this + " " + clr + ".</span>" );
				this.icon_state = "egg-" + clr;
				this.item_color = clr;
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: snacks_egg.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			dynamic T = null;

			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				T = GlobalFuncs.get_turf( target );
				new Obj_Effect_Decal_Cleanable_EggSmudge( T );
				this.reagents.reaction( target, GlobalVars.TOUCH );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

	}

}