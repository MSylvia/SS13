// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Generic_Cauterize : SurgeryStep_Generic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Cautery), 100 )
				.Set( typeof(Obj_Item_Weapon_Scalpel_Laser), 100 )
				.Set( typeof(Obj_Item_Clothing_Mask_Cigarette), 75 )
				.Set( typeof(Obj_Item_Weapon_Lighter), 50 )
				.Set( typeof(Obj_Item_Weapon_Weldingtool), 25 )
			;
			this.min_duration = 70;
			this.max_duration = 100;
		}

		// Function from file: generic.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			string affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( "'s hand slips, leaving a small burn on " ).item( target ).str( "'s " ).item( ((dynamic)affected).display_name ).str( " with " ).the( tool ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>Your hand slips, leaving a small burn on " ).item( target ).str( "'s " ).item( ((dynamic)affected).display_name ).str( " with " ).the( tool ).item().str( "!</span>" ).ToString() );
			((Mob_Living)target).apply_damage( 3, "fire", affected );
			return null;
		}

		// Function from file: generic.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " cauterizes the incision on " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You cauterize the incision on " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( ".</span>" ).ToString() );
			affected.open = 0;
			affected.germ_level = 0;
			affected.status &= 65527;
			return false;
		}

		// Function from file: generic.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			((Ent_Static)user).visible_message( new Txt().item( user ).str( " is beginning to cauterize the incision on " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( "." ).ToString(), new Txt( "You are beginning to cauterize the incision on " ).item( target ).str( "'s " ).item( affected.display_name ).str( " with " ).the( tool ).item().str( "." ).ToString() );
			((Mob_Living_Carbon_Human)target).custom_pain( "Your " + affected.display_name + " is being burned!", true );
			base.begin_step( (object)(user), (object)(target), target_zone, tool, (object)(surgery) );
			return false;
		}

		// Function from file: generic.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			dynamic affected = null;

			
			if ( base.can_use( (object)(user), (object)(target), target_zone, tool ) != 0 ) {
				
				if ( Lang13.Bool( target.species ) && Lang13.Bool( target.species.flags & 32768 ) ) {
					GlobalFuncs.to_chat( user, "<span class='info'>" + target + " has no skin!</span>" );
					return 0;
				}
				affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
				return Lang13.Bool( affected.open ) && target_zone != "mouth" ?1:0;
			}
			return 0;
		}

		// Function from file: generic.dm
		public override bool tool_quality( Obj_Item tool = null ) {
			dynamic T = null;

			
			if ( Lang13.Bool( tool.is_hot() ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.allowed_tools )) {
					T = _a;
					

					if ( Lang13.Bool( T.IsInstanceOfType( tool ) ) ) {
						return Lang13.Bool( this.allowed_tools[T] );
					}
				}
			}
			return false;
		}

	}

}