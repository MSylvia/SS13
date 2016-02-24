// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Reagentgrinder : Obj_Machinery {

		public bool operating = false;
		public dynamic beaker = null;
		public int limit = 10;
		public ByTable blend_items = new ByTable()
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Plasma), new ByTable().Set( "plasma", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Metal), new ByTable().Set( "iron", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Plasteel), new ByTable().Set( "iron", 20 ).Set( "plasma", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Wood), new ByTable().Set( "carbon", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Glass), new ByTable().Set( "silicon", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Rglass), new ByTable().Set( "silicon", 20 ).Set( "iron", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Uranium), new ByTable().Set( "uranium", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Bananium), new ByTable().Set( "banana", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Silver), new ByTable().Set( "silver", 20 ) )
											.Set( typeof(Obj_Item_Stack_Sheet_Mineral_Gold), new ByTable().Set( "gold", 20 ) )
											.Set( typeof(Obj_Item_Weapon_Grown_Nettle_Basic), new ByTable().Set( "sacid", 0 ) )
											.Set( typeof(Obj_Item_Weapon_Grown_Nettle_Death), new ByTable().Set( "facid", 0 ) )
											.Set( typeof(Obj_Item_Weapon_Grown_Novaflower), new ByTable().Set( "capsaicin", 0 ).Set( "condensedcapsaicin", 0 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Red), new ByTable().Set( "redcrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Orange), new ByTable().Set( "orangecrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Yellow), new ByTable().Set( "yellowcrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Green), new ByTable().Set( "greencrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Blue), new ByTable().Set( "bluecrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Purple), new ByTable().Set( "purplecrayonpowder", 10 ) )
											.Set( typeof(Obj_Item_Toy_Crayon_Mime), new ByTable().Set( "invisiblecrayonpowder", 50 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Soybeans), new ByTable().Set( "soymilk", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), new ByTable().Set( "ketchup", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Corn), new ByTable().Set( "cornoil", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Wheat), new ByTable().Set( "flour", -5 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Oat), new ByTable().Set( "flour", -5 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cherries), new ByTable().Set( "cherryjelly", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Bluecherries), new ByTable().Set( "bluecherryjelly", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg), new ByTable().Set( "eggyolk", -5 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Arabica), new ByTable().Set( "coffeepowder", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Robusta), new ByTable().Set( "coffeepowder", 0 ).Set( "morphine", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Aspera), new ByTable().Set( "teapowder", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Astra), new ByTable().Set( "teapowder", 0 ).Set( "salglu_solution", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Pill), new ByTable() )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food), new ByTable() )
										;
		public ByTable juice_items = new ByTable()
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Corn), new ByTable().Set( "corn_starch", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), new ByTable().Set( "tomatojuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), new ByTable().Set( "carrotjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries), new ByTable().Set( "berryjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), new ByTable().Set( "banana", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato), new ByTable().Set( "potato", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lemon), new ByTable().Set( "lemonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Orange), new ByTable().Set( "orangejuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lime), new ByTable().Set( "limejuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Watermelon), new ByTable().Set( "watermelonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Watermelonslice), new ByTable().Set( "watermelonjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Poison), new ByTable().Set( "poisonberryjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Pumpkin), new ByTable().Set( "pumpkinjuice", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Blumpkin), new ByTable().Set( "blumpkinjuice", 0 ) )
										;
		public ByTable dried_items = new ByTable()
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Arabica), new ByTable().Set( "coffeepowder", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Coffee_Robusta), new ByTable().Set( "coffeepowder", 0 ).Set( "morphine", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Aspera), new ByTable().Set( "teapowder", 0 ) )
											.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Astra), new ByTable().Set( "teapowder", 0 ).Set( "salglu_solution", 0 ) )
										;
		public ByTable holdingitems = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 5;
			this.active_power_usage = 100;
			this.pass_flags = 1;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "juicer1";
			this.layer = 2.9;
		}

		// Function from file: reagentgrinder.dm
		public Obj_Machinery_Reagentgrinder ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.beaker = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large( this );
			return;
		}

		// Function from file: reagentgrinder.dm
		public void grind(  ) {
			int offset = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null;
			dynamic allowed = null;
			dynamic r_id = null;
			dynamic space = null;
			double amount = 0;
			Obj_Item_Stack_Sheet O2 = null;
			dynamic allowed2 = null;
			double? i = null;
			dynamic r_id2 = null;
			dynamic space2 = null;
			double amount2 = 0;
			Obj_Item_Weapon_Grown O3 = null;
			dynamic allowed3 = null;
			dynamic r_id3 = null;
			dynamic space3 = null;
			bool amount3 = false;
			Obj_Item_Toy_Crayon O4 = null;
			dynamic allowed4 = null;
			dynamic r_id4 = null;
			dynamic space4 = null;
			double amount4 = 0;
			Obj_Item_Weapon_ReagentContainers O5 = null;
			double? amount5 = null;

			this.power_change();

			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}

			if ( !Lang13.Bool( this.beaker ) || Lang13.Bool( this.beaker ) && ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
				return;
			}
			GlobalFuncs.playsound( this.loc, "sound/machines/blender.ogg", 50, 1 );
			offset = ( Rand13.PercentChance( 50 ) ? -2 : 2 );
			Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_x", this.pixel_x + offset ).Set( "time", 0.2 ).Set( "loop", 250 ) );
			this.operating = true;
			this.updateUsrDialog();
			Task13.Schedule( 60, (Task13.Closure)(() => {
				this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
				this.operating = false;
				this.updateUsrDialog();
				return;
			}));

			foreach (dynamic _b in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks) )) {
				O = _b;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed = this.get_allowed_snack_by_id( O );

				if ( allowed == null ) {
					break;
				}

				foreach (dynamic _a in Lang13.Enumerate( allowed )) {
					r_id = _a;
					
					space = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount = Convert.ToDouble( allowed[r_id] );

					if ( amount <= 0 ) {
						
						if ( amount == 0 ) {
							
							if ( O.reagents != null && Lang13.Bool( O.reagents.has_reagent( "nutriment" ) ) ) {
								this.beaker.reagents.add_reagent( r_id, Num13.MinInt( O.reagents.get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
								O.reagents.remove_reagent( "nutriment", Num13.MinInt( O.reagents.get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
							}
						} else if ( O.reagents != null && Lang13.Bool( O.reagents.has_reagent( "nutriment" ) ) ) {
							this.beaker.reagents.add_reagent( r_id, Num13.MinInt( Num13.Floor( ( O.reagents.get_reagent_amount( "nutriment" ) ?1:0) * Math.Abs( amount ) ), Convert.ToInt32( space ) ) );
							O.reagents.remove_reagent( "nutriment", Num13.MinInt( O.reagents.get_reagent_amount( "nutriment" ) ?1:0, Convert.ToInt32( space ) ) );
						}
					} else {
						O.reagents.trans_id_to( this.beaker, r_id, Num13.MinInt( ((int)( amount )), Convert.ToInt32( space ) ) );
					}

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}

				if ( O.reagents.reagent_list.len == 0 ) {
					this.remove_object( O );
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Stack_Sheet) )) {
				O2 = _d;
				
				allowed2 = this.get_allowed_by_id( O2 );

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				i = null;
				i = 1;

				while (( i ??0) <= Num13.Round( O2.amount ??0, 1 )) {
					
					foreach (dynamic _c in Lang13.Enumerate( allowed2 )) {
						r_id2 = _c;
						
						space2 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
						amount2 = Convert.ToDouble( allowed2[r_id2] );
						this.beaker.reagents.add_reagent( r_id2, Num13.MinInt( ((int)( amount2 )), Convert.ToInt32( space2 ) ) );

						if ( Convert.ToDouble( space2 ) < amount2 ) {
							break;
						}
					}

					if ( i == Num13.Round( O2.amount ??0, 1 ) ) {
						this.remove_object( O2 );
						break;
					}
					i++;
				}
			}

			foreach (dynamic _f in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_Grown) )) {
				O3 = _f;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed3 = this.get_allowed_by_id( O3 );

				foreach (dynamic _e in Lang13.Enumerate( allowed3 )) {
					r_id3 = _e;
					
					space3 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount3 = Lang13.Bool( allowed3[r_id3] );

					if ( !amount3 ) {
						
						if ( O3.reagents != null && Lang13.Bool( O3.reagents.has_reagent( r_id3 ) ) ) {
							this.beaker.reagents.add_reagent( r_id3, Num13.MinInt( O3.reagents.get_reagent_amount( r_id3 ) ?1:0, Convert.ToInt32( space3 ) ) );
						}
					} else {
						this.beaker.reagents.add_reagent( r_id3, Num13.MinInt( amount3 ?1:0, Convert.ToInt32( space3 ) ) );
					}

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}
				this.remove_object( O3 );
			}

			foreach (dynamic _h in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Toy_Crayon) )) {
				O4 = _h;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed4 = this.get_allowed_by_id( O4 );

				foreach (dynamic _g in Lang13.Enumerate( allowed4 )) {
					r_id4 = _g;
					
					space4 = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount4 = Convert.ToDouble( allowed4[r_id4] );
					this.beaker.reagents.add_reagent( r_id4, Num13.MinInt( ((int)( amount4 )), Convert.ToInt32( space4 ) ) );

					if ( Convert.ToDouble( space4 ) < amount4 ) {
						break;
					}
					this.remove_object( O4 );
				}
			}

			foreach (dynamic _i in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers) )) {
				O5 = _i;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				amount5 = O5.reagents.total_volume;
				O5.reagents.trans_to( this.beaker, amount5 );

				if ( !Lang13.Bool( O5.reagents.total_volume ) ) {
					this.remove_object( O5 );
				}
			}
			return;
		}

		// Function from file: reagentgrinder.dm
		public void juice(  ) {
			int offset = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null;
			dynamic allowed = null;
			dynamic r_id = null;
			dynamic space = null;
			int amount = 0;

			this.power_change();

			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}

			if ( !Lang13.Bool( this.beaker ) || Lang13.Bool( this.beaker ) && ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
				return;
			}
			GlobalFuncs.playsound( this.loc, "sound/machines/juicer.ogg", 20, 1 );
			offset = ( Rand13.PercentChance( 50 ) ? -2 : 2 );
			Icon13.Animate( new ByTable().Set( 1, this ).Set( "pixel_x", this.pixel_x + offset ).Set( "time", 0.2 ).Set( "loop", 250 ) );
			this.operating = true;
			this.updateUsrDialog();
			Task13.Schedule( 50, (Task13.Closure)(() => {
				this.pixel_x = Convert.ToInt32( Lang13.Initial( this, "pixel_x" ) );
				this.operating = false;
				this.updateUsrDialog();
				return;
			}));

			foreach (dynamic _b in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks) )) {
				O = _b;
				

				if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
					break;
				}
				allowed = this.get_allowed_juice_by_id( O );

				if ( allowed == null ) {
					break;
				}

				foreach (dynamic _a in Lang13.Enumerate( allowed )) {
					r_id = _a;
					
					space = this.beaker.reagents.maximum_volume - this.beaker.reagents.total_volume;
					amount = this.get_juice_amount( O );
					this.beaker.reagents.add_reagent( r_id, Num13.MinInt( amount, Convert.ToInt32( space ) ) );

					if ( ( this.beaker.reagents.total_volume ??0) >= Convert.ToDouble( this.beaker.reagents.maximum_volume ) ) {
						break;
					}
				}
				this.remove_object( O );
			}
			return;
		}

		// Function from file: reagentgrinder.dm
		public void remove_object( Obj_Item O = null ) {
			this.holdingitems.Remove( O );
			GlobalFuncs.qdel( O );
			return;
		}

		// Function from file: reagentgrinder.dm
		public int get_juice_amount( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			
			if ( !( O is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ) ) {
				return 5;
			} else if ( O.potency == -1 ) {
				return 5;
			} else {
				return Num13.Floor( Math.Sqrt( O.potency ??0 ) * 5 );
			}
			return 0;
		}

		// Function from file: reagentgrinder.dm
		public int get_grownweapon_amount( dynamic O = null ) {
			
			if ( !( O is Obj_Item_Weapon_Grown ) ) {
				return 5;
			} else if ( Convert.ToInt32( O.potency ) == -1 ) {
				return 5;
			} else {
				return Num13.Floor( Convert.ToDouble( O.potency ) );
			}
			return 0;
		}

		// Function from file: reagentgrinder.dm
		public dynamic get_allowed_juice_by_id( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.juice_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.juice_items[i];
				}
			}
			return null;
		}

		// Function from file: reagentgrinder.dm
		public dynamic get_allowed_snack_by_id( Obj_Item_Weapon_ReagentContainers_Food_Snacks O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.blend_items[i];
				}
			}
			return null;
		}

		// Function from file: reagentgrinder.dm
		public dynamic get_allowed_by_id( Obj_Item O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return this.blend_items[i];
				}
			}
			return null;
		}

		// Function from file: reagentgrinder.dm
		public bool is_allowed( dynamic O = null ) {
			dynamic i = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.blend_items )) {
				i = _a;
				

				if ( Lang13.Bool( i.IsInstanceOfType( O ) ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: reagentgrinder.dm
		public void eject(  ) {
			Obj_Item O = null;

			
			if ( Task13.User.stat != 0 ) {
				return;
			}

			if ( this.holdingitems != null && this.holdingitems.len == 0 ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item) )) {
				O = _a;
				
				O.loc = this.loc;
				this.holdingitems.Remove( O );
			}
			this.holdingitems = new ByTable();
			this.updateUsrDialog();
			return;
		}

		// Function from file: reagentgrinder.dm
		public void detach(  ) {
			
			if ( Task13.User.stat != 0 ) {
				return;
			}

			if ( !Lang13.Bool( this.beaker ) ) {
				return;
			}
			this.beaker.loc = this.loc;
			this.beaker = null;
			this.update_icon();
			this.updateUsrDialog();
			return;
		}

		// Function from file: reagentgrinder.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( this.operating ) {
				this.updateUsrDialog();
				return null;
			}

			dynamic _a = href_list["action"]; // Was a switch-case, sorry for the mess.
			if ( _a=="grind" ) {
				this.grind();
			} else if ( _a=="juice" ) {
				this.juice();
			} else if ( _a=="eject" ) {
				this.eject();
			} else if ( _a=="detach" ) {
				this.detach();
			}
			return null;
		}

		// Function from file: reagentgrinder.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			bool is_chamber_empty = false;
			bool is_beaker_ready = false;
			string processing_chamber = null;
			string beaker_contents = null;
			string dat = null;
			Obj_Item O = null;
			bool anything = false;
			Reagent R = null;
			Browser popup = null;

			is_chamber_empty = false;
			is_beaker_ready = false;
			processing_chamber = "";
			beaker_contents = "";
			dat = "";

			if ( !this.operating ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.holdingitems, typeof(Obj_Item) )) {
					O = _a;
					
					processing_chamber += new Txt().A( O.name ).item().str( "<BR>" ).ToString();
				}

				if ( !Lang13.Bool( processing_chamber ) ) {
					is_chamber_empty = true;
					processing_chamber = "Nothing.";
				}

				if ( !Lang13.Bool( this.beaker ) ) {
					beaker_contents = "<B>No beaker attached.</B><br>";
				} else {
					is_beaker_ready = true;
					beaker_contents = "<B>The beaker contains:</B><br>";
					anything = false;

					foreach (dynamic _b in Lang13.Enumerate( this.beaker.reagents.reagent_list, typeof(Reagent) )) {
						R = _b;
						
						anything = true;
						beaker_contents += "" + R.volume + " - " + R.name + "<br>";
					}

					if ( !anything ) {
						beaker_contents += "Nothing<br>";
					}
				}
				dat = "\n		<b>Processing chamber contains:</b><br>\n		" + processing_chamber + "<br>\n		" + beaker_contents + "<hr>\n		";

				if ( is_beaker_ready && !is_chamber_empty && !( ( this.stat & 3 ) != 0 ) ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=grind'>Grind the reagents</a><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=juice'>Juice the reagents</a><BR><BR>" ).ToString();
				}

				if ( this.holdingitems != null && this.holdingitems.len > 0 ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=eject'>Eject the reagents</a><BR>" ).ToString();
				}

				if ( Lang13.Bool( this.beaker ) ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";action=detach'>Detach the beaker</a><BR>" ).ToString();
				}
			} else {
				dat += "Please wait...";
			}
			popup = new Browser( user, "reagentgrinder", "All-In-One Grinder" );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open( true );
			return null;
		}

		// Function from file: reagentgrinder.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).set_machine( this );
			this.interact( a );
			return null;
		}

		// Function from file: reagentgrinder.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return 0;
		}

		// Function from file: reagentgrinder.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: reagentgrinder.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic G = null;
			dynamic B = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown G2 = null;

			
			if ( this.default_unfasten_wrench( user, A ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_ReagentContainers && Lang13.Bool( A.flags & 4096 ) ) {
				
				if ( Lang13.Bool( this.beaker ) ) {
					return 1;
				} else {
					
					if ( !Lang13.Bool( user.drop_item() ) ) {
						return 1;
					}
					this.beaker = A;
					this.beaker.loc = this;
					this.update_icon();
					this.updateUsrDialog();
					return 0;
				}
			}

			if ( GlobalFuncs.is_type_in_list( A, this.dried_items ) ) {
				
				if ( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ) {
					G = A;

					if ( !G.dry ) {
						user.WriteMsg( "<span class='warning'>You must dry that first!</span>" );
						return 1;
					}
				}
			}

			if ( this.holdingitems != null && this.holdingitems.len >= this.limit ) {
				Task13.User.WriteMsg( "The machine cannot hold anymore items." );
				return 1;
			}

			if ( A is Obj_Item_Weapon_Storage_Bag ) {
				B = A;

				foreach (dynamic _a in Lang13.Enumerate( B.contents, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown) )) {
					G2 = _a;
					
					((Obj_Item_Weapon_Storage)B).remove_from_storage( G2, this );
					this.holdingitems.Add( G2 );

					if ( this.holdingitems != null && this.holdingitems.len >= this.limit ) {
						user.WriteMsg( "<span class='notice'>You fill the All-In-One grinder to the brim.</span>" );
						break;
					}
				}

				if ( !( A.contents.len != 0 ) ) {
					user.WriteMsg( "<span class='notice'>You empty the plant bag into the All-In-One grinder.</span>" );
				}
				this.updateUsrDialog();
				return 0;
			}

			if ( !GlobalFuncs.is_type_in_list( A, this.blend_items ) && !GlobalFuncs.is_type_in_list( A, this.juice_items ) ) {
				user.WriteMsg( "<span class='warning'>Cannot refine into a reagent!</span>" );
				return 1;
			}
			((Mob)user).unEquip( A );
			A.loc = this;
			this.holdingitems.Add( A );
			this.updateUsrDialog();
			return 0;
		}

		// Function from file: reagentgrinder.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "juicer" + String13.NumberToString( !( this.beaker == null ) ?1:0 );
			return false;
		}

	}

}