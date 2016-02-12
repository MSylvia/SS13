// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Dropper : Obj_Item_Weapon_ReagentContainers {

		public ByTable injectable_types = new ByTable(new object [] { 
											typeof(Obj_Item_Weapon_ReagentContainers_Food), 
											typeof(Obj_Item_SlimeExtract), 
											typeof(Obj_Item_Clothing_Mask_Cigarette), 
											typeof(Obj_Item_Weapon_Storage_Fancy_Cigarettes), 
											typeof(Obj_Item_Weapon_Implantcase_Chem), 
											typeof(Obj_Item_Weapon_ReagentContainers_Pill_TimeRelease)
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable(new object [] { 1, 2, 3, 4, 5 });
			this.volume = 5;
			this.icon_state = "dropper0";
		}

		public Obj_Item_Weapon_ReagentContainers_Dropper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: dropper.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			ByTable bad_reagents = null;
			dynamic trans = null;
			dynamic victim = null;
			dynamic safe_thing = null;
			dynamic M = null;
			ByTable injected = null;
			Reagent R = null;
			string contained = null;
			dynamic trans2 = null;

			
			if ( !( flag == true ) ) {
				return false;
			}

			if ( !Lang13.Bool( A.reagents ) ) {
				
				if ( Lang13.Bool( this.reagents.total_volume ) ) {
					
					if ( A is Obj_Machinery_Artifact ) {
						((Reagents)this.reagents).clear_reagents();
						GlobalFuncs.to_chat( user, "<span class='notice'>You squirt the solution onto the " + A + "!</span>" );
						this.update_icon();
					}
				}
				return false;
			}
			bad_reagents = ((Reagents)this.reagents).get_bad_reagent_names();

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				
				if ( ( A.reagents.total_volume ??0) >= Convert.ToDouble( A.reagents.maximum_volume ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>" + A + " is full.</span>" );
					return false;
				}

				if ( !Lang13.Bool( ((Ent_Static)A).is_open_container() ) && !( A is Mob ) && !GlobalFuncs.is_type_in_list( A, this.injectable_types ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You cannot directly fill this object.</span>" );
					return false;
				}
				trans = 0;

				if ( A is Mob ) {
					
					if ( A is Mob_Living_Carbon_Human ) {
						victim = A;
						safe_thing = ((Mob_Living_Carbon_Human)victim).get_body_part_coverage( 2048 );

						if ( Lang13.Bool( safe_thing ) ) {
							
							if ( !Lang13.Bool( safe_thing.reagents ) ) {
								((Ent_Static)safe_thing).create_reagents( 100 );
							}
							trans = ((Reagents)this.reagents).trans_to( safe_thing, this.amount_per_transfer_from_this );
							((Ent_Static)user).visible_message( "<span class='danger'>" + user + " tries to squirt something into " + A + "'s eyes, but fails!</span>" );
							Task13.Schedule( 5, (Task13.Closure)(() => {
								((Reagents)this.reagents).reaction( safe_thing, GlobalVars.TOUCH );
								return;
							}));
							GlobalFuncs.to_chat( user, "<span class='notice'>You transfer " + trans + " units of the solution.</span>" );
							this.update_icon();
							return false;
						}
					}
					((Ent_Static)user).visible_message( "<span class='danger'>" + user + " squirts something into " + A + "'s eyes!</span>" );
					((Reagents)this.reagents).reaction( A, GlobalVars.TOUCH );
					M = A;
					injected = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
						R = _a;
						
						injected.Add( R.name );
					}
					contained = GlobalFuncs.english_list( injected );
					M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been squirted with " + this.name + " by " + user.name + " (" + user.ckey + "). Reagents: " + contained + "</font>" );
					user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to squirt " + M.name + " (" + M.key + "). Reagents: " + contained + "</font>" );
					GlobalFuncs.msg_admin_attack( "" + user.name + " (" + user.ckey + ") squirted " + M.name + " (" + M.key + ") with " + this.name + ". Reagents: " + contained + " (INTENT: " + String13.ToUpper( user.a_intent ) + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + user.x + ";Y=" + user.y + ";Z=" + user.z + "'>JMP</a>)" );

					if ( !( user is Mob_Living_Carbon ) ) {
						M.LAssailant = null;
					} else {
						M.LAssailant = user;
					}
				}
				trans = ((Reagents)this.reagents).trans_to( A, this.amount_per_transfer_from_this );
				GlobalFuncs.to_chat( user, "<span class='notice'>You transfer " + trans + " units of the solution.</span>" );
				this.update_icon();

				if ( A is Obj ) {
					
					if ( GlobalVars.reagents_to_log is ByTable && GlobalVars.reagents_to_log.len != 0 && A.log_reagents ) {
						GlobalFuncs.log_reagents( user, this, A, trans, bad_reagents );
					}
				}
			} else {
				
				if ( !Lang13.Bool( ((Ent_Static)A).is_open_container() ) && !( A is Obj_Structure_ReagentDispensers ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You cannot directly remove reagents from " + A + ".</span>" );
					return false;
				}

				if ( !Lang13.Bool( A.reagents.total_volume ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>" + A + " is empty.</span>" );
					return false;
				}
				trans2 = ((Reagents)A.reagents).trans_to( this, this.amount_per_transfer_from_this );

				if ( GlobalVars.reagents_to_log is ByTable && GlobalVars.reagents_to_log.len != 0 && A.log_reagents ) {
					GlobalFuncs.log_reagents( user, this, A, trans2, bad_reagents );
				}
				GlobalFuncs.to_chat( user, "<span class='notice'>You fill " + this + " with " + trans2 + " units of the solution.</span>" );
				this.update_icon();
			}
			return false;
		}

		// Function from file: dropper.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "dropper" + ( Lang13.Bool( this.reagents.total_volume ) ? true : false );
			return null;
		}

	}

}