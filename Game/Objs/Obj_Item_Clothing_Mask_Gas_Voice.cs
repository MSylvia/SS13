// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Gas_Voice : Obj_Item_Clothing_Mask_Gas {

		public bool mode = false;
		public string voice = "Unknown";
		public bool vchange = true;
		public ByTable clothing_choices = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "syndicate=4";
			this.species_fit = new ByTable(new object [] { "Vox" });
		}

		// Function from file: gasmask.dm
		public Obj_Item_Clothing_Mask_Gas_Voice ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic Type = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Obj_Item_Clothing_Mask) ) - new ByTable(new object [] { typeof(Obj_Item_Clothing_Mask), typeof(Obj_Item_Clothing_Mask_Gas_Voice) }) )) {
				Type = _a;
				
				this.clothing_choices.Add( Lang13.Call( Type ) );
			}
			return;
		}

		// Function from file: gasmask.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.vchange = !this.vchange;
			GlobalFuncs.to_chat( user, "<span class='notice'>The voice changer is now " + ( this.vchange ? "on" : "off" ) + "!</span>" );
			return null;
		}

		// Function from file: gasmask.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic M = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( !( a is Obj_Item_Clothing_Mask ) || Lang13.Bool( ((dynamic)this.type).IsInstanceOfType( a ) ) ) {
				return 0;
			} else {
				M = a;

				if ( this.clothing_choices.Find( M ) != 0 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + M.name + "'s pattern is already stored.</span>" );
					return null;
				}
				this.clothing_choices.Add( M );
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>" ).item( M.name ).str( "'s pattern absorbed by " ).the( this ).item().str( ".</span>" ).ToString() );
				return 1;
			}
		}

		// Function from file: gasmask.dm
		[Verb]
		[VerbInfo( name: "Change Mask Form", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void change(  ) {
			dynamic A = null;

			A = Interface13.Input( "Select Form to change it to", "BOOYEA", A, null, this.clothing_choices, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( A ) || Lang13.Bool( Task13.User.stat ) ) {
				return;
			}
			this.desc = null;
			this.permeability_coefficient = 081;
			this.desc = A.desc;
			this.name = A.name;
			this.icon = A.icon;
			this.icon_state = A.icon_state;
			this.item_state = A.item_state;
			this.body_parts_covered = A.body_parts_covered;
			Task13.User.update_inv_wear_mask( true );
			return;
		}

	}

}