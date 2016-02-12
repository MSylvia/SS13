// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Swapmap : Game_Data {

		public dynamic id = null;
		public int x1 = 0;
		public int y1 = 0;
		public int? z1 = null;
		public int x2 = 0;
		public int y2 = 0;
		public int? z2 = null;
		public bool locked = false;
		public bool mode = false;
		public bool ischunk = false;

		// Function from file: swapmaps.dm
		public Swapmap ( dynamic __id = null, dynamic x = null, dynamic y = null, dynamic z = null ) {
			
			if ( __id == null ) {
				return;
			}
			this.id = __id;
			this.mode = GlobalVars.swapmaps_mode;

			if ( x is Tile && y is Tile ) {
				this.x1 = Num13.MinInt( Convert.ToInt32( x.x ), Convert.ToInt32( y.x ) );
				this.x2 = Num13.MaxInt( Convert.ToInt32( x.x ), Convert.ToInt32( y.x ) );
				this.y1 = Num13.MinInt( Convert.ToInt32( x.y ), Convert.ToInt32( y.y ) );
				this.y2 = Num13.MaxInt( Convert.ToInt32( x.y ), Convert.ToInt32( y.y ) );
				this.z1 = Num13.MinInt( Convert.ToInt32( x.z ), Convert.ToInt32( y.z ) );
				this.z2 = Num13.MaxInt( Convert.ToInt32( x.z ), Convert.ToInt32( y.z ) );
				GlobalFuncs.InitializeSwapMaps();

				if ( ( this.z2 ??0) > GlobalVars.swapmaps_compiled_maxz || this.y2 > GlobalVars.swapmaps_compiled_maxy || this.x2 > GlobalVars.swapmaps_compiled_maxx ) {
					Lang13.Delete( this );
					Task13.Source = null;
					return;
				}
				return;
			}
			this.x2 = ( Lang13.Bool( x ) ? Convert.ToInt32( x ) : Game13.map_size_x );
			this.y2 = ( Lang13.Bool( y ) ? Convert.ToInt32( y ) : Game13.map_size_y );
			this.z2 = ( Lang13.Bool( z ) ? Lang13.Bool( z ) : true ) ?1:0;
			this.AllocateSwapMap();
			return;
		}

		// Function from file: swapmaps.dm
		public void BuildInTurfs( dynamic turfs = null, dynamic item = null ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( turfs )) {
				T = _a;
				
				Lang13.Call( item, T );
			}
			return;
		}

		// Function from file: swapmaps.dm
		public void BuildRectangle( Tile T1 = null, Tile T2 = null, dynamic item = null ) {
			dynamic T = null;

			
			if ( !this.Contains( T1 ) || !this.Contains( T2 ) ) {
				return;
			}
			T = T1;
			T1 = Map13.GetTile( Num13.MinInt( T1.x, T2.x ), Num13.MinInt( T1.y, T2.y ), Num13.MinInt( T1.z, T2.z ) );
			T2 = Map13.GetTile( Num13.MaxInt( Convert.ToInt32( T.x ), T2.x ), Num13.MaxInt( Convert.ToInt32( T.y ), T2.y ), Num13.MaxInt( Convert.ToInt32( T.z ), T2.z ) );

			if ( T2.x - T1.x < 2 || T2.y - T1.y < 2 ) {
				this.BuildFilledRectangle( T1, T2, item );
			} else {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInBlock( T1, Map13.GetTile( T2.x, T1.y, T2.z ) ) )) {
					T = _a;
					
					Lang13.Call( item, T );
				}

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( T1.x, T2.y, T1.z ), T2 ) )) {
					T = _b;
					
					Lang13.Call( item, T );
				}

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( T1.x, T1.y + 1, T1.z ), Map13.GetTile( T1.x, T2.y - 1, T2.z ) ) )) {
					T = _c;
					
					Lang13.Call( item, T );
				}

				foreach (dynamic _d in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( T2.x, T1.y + 1, T1.z ), Map13.GetTile( T2.x, T2.y - 1, T2.z ) ) )) {
					T = _d;
					
					Lang13.Call( item, T );
				}
			}
			return;
		}

		// Function from file: swapmaps.dm
		public void BuildFilledRectangle( Tile T1 = null, Tile T2 = null, dynamic item = null ) {
			dynamic T = null;

			
			if ( !this.Contains( T1 ) || !this.Contains( T2 ) ) {
				return;
			}
			T = T1;
			T1 = Map13.GetTile( Num13.MinInt( T1.x, T2.x ), Num13.MinInt( T1.y, T2.y ), Num13.MinInt( T1.z, T2.z ) );
			T2 = Map13.GetTile( Num13.MaxInt( Convert.ToInt32( T.x ), T2.x ), Num13.MaxInt( Convert.ToInt32( T.y ), T2.y ), Num13.MaxInt( Convert.ToInt32( T.z ), T2.z ) );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInBlock( T1, T2 ) )) {
				T = _a;
				
				Lang13.Call( item, T );
			}
			return;
		}

		// Function from file: swapmaps.dm
		public Tile HiCorner( int? z = null ) {
			z = z ?? this.z2;

			return Map13.GetTile( this.x2, this.y2, z ??0 );
		}

		// Function from file: swapmaps.dm
		public Tile LoCorner( int? z = null ) {
			z = z ?? this.z1;

			return Map13.GetTile( this.x1, this.y1, z ??0 );
		}

		// Function from file: swapmaps.dm
		public bool InUse(  ) {
			dynamic T = null;
			dynamic M = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.AllTurfs() )) {
				T = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( T )) {
					M = _a;
					

					if ( Lang13.Bool( M.key ) ) {
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: swapmaps.dm
		public bool Contains( Tile T = null ) {
			return T != null && T.x >= this.x1 && T.x <= this.x2 && T.y >= this.y1 && T.y <= this.y2 && T.z >= ( this.z1 ??0) && T.z <= ( this.z2 ??0);
		}

		// Function from file: swapmaps.dm
		public ByTable AllTurfs( int? z = null ) {
			
			if ( Lang13.Bool( Lang13.IsNumber( z ) ) && ( ( z ??0) < ( this.z1 ??0) || ( z ??0) > ( this.z2 ??0) ) ) {
				return null;
			}
			return Map13.FetchInBlock( this.LoCorner( z ), this.HiCorner( z ) );
		}

		// Function from file: swapmaps.dm
		public void SetID( dynamic newid = null ) {
			GlobalVars.swapmaps_byname.Remove( this.id );
			this.id = newid;
			GlobalVars.swapmaps_byname[this.id] = this;
			return;
		}

		// Function from file: swapmaps.dm
		public bool Save(  ) {
			SaveFile S = null;

			
			if ( this.id == this ) {
				return false;
			}
			S = ( this.mode ? new SaveFile() : new SaveFile( "map_" + this.id + ".sav" ) );
			((dynamic)S).WriteMsg( this );

			while (this.locked) {
				Task13.Sleep( 1 );
			}

			if ( this.mode ) {
				File13.Delete( "map_" + this.id + ".txt" );
				S.ExportText( "/", "map_" + this.id + ".txt" );
			}
			return true;
		}

		// Function from file: swapmaps.dm
		public void Unload(  ) {
			this.Save();
			Lang13.Delete( this );
			Task13.Source = null;
			return;
		}

		// Function from file: swapmaps.dm
		public void CutXYZ(  ) {
			int mx = 0;
			int my = 0;
			int mz = 0;
			Swapmap M = null;

			mx = GlobalVars.swapmaps_compiled_maxx;
			my = GlobalVars.swapmaps_compiled_maxy;
			mz = GlobalVars.swapmaps_compiled_maxz;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.swapmaps_loaded, typeof(Swapmap) )) {
				M = _a;
				
				mx = Num13.MaxInt( mx, M.x2 );
				my = Num13.MaxInt( my, M.y2 );
				mz = Num13.MaxInt( mz, M.z2 ??0 );
			}
			Game13.map_size_x = mx;
			Game13.map_size_y = my;
			Game13.map_size_z = mz;
			return;
		}

		// Function from file: swapmaps.dm
		public ByTable ConsiderRegion( int X1 = 0, int Y1 = 0, int X2 = 0, int Y2 = 0, int? Z1 = null, int? Z2 = null ) {
			ByTable _default = null;

			int nextz = 0;
			Swapmap M = null;
			int? nz2 = null;

			
			while (true) {
				nextz = 0;

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.swapmaps_loaded, typeof(Swapmap) )) {
					M = _a;
					

					if ( ( M.z2 ??0) < ( Z1 ??0) || Lang13.Bool( Z2 ) && ( M.z1 ??0) > ( Z2 ??0) || ( M.z1 ??0) >= ( Z1 ??0) + ( this.z2 ??0) || M.x1 > X2 || M.x2 < X1 || M.x1 >= X1 + this.x2 || M.y1 > Y2 || M.y2 < Y1 || M.y1 >= Y1 + this.y2 ) {
						continue;
					}
					nz2 = ( Lang13.Bool( Z2 ) ? Z2 : ( Z1 ??0) + ( this.z2 ??0) - 1 + ( M.z2 ??0) - ( M.z1 ??0) );

					if ( M.x1 >= X1 + this.x2 ) {
						_default = this.ConsiderRegion( X1, Y1, M.x1 - 1, Y2, Z1, nz2 );

						if ( _default != null ) {
							return _default;
						}
					} else if ( M.x2 <= X2 - this.x2 ) {
						_default = this.ConsiderRegion( M.x2 + 1, Y1, X2, Y2, Z1, nz2 );

						if ( _default != null ) {
							return _default;
						}
					}

					if ( M.y1 >= Y1 + this.y2 ) {
						_default = this.ConsiderRegion( X1, Y1, X2, M.y1 - 1, Z1, nz2 );

						if ( _default != null ) {
							return _default;
						}
					} else if ( M.y2 <= Y2 - this.y2 ) {
						_default = this.ConsiderRegion( X1, M.y2 + 1, X2, Y2, Z1, nz2 );

						if ( _default != null ) {
							return _default;
						}
					}
					nextz = ( nextz != 0 ? Num13.MinInt( nextz, ( M.z2 ??0) + 1 ) : ( M.z2 ??0) + 1 );
				}

				if ( !( M != null ) ) {
					
					if ( nextz != 0 ) {
						Z1 = nextz;
					}

					if ( !( nextz != 0 ) || Lang13.Bool( Z2 ) && ( Z2 ??0) - ( Z1 ??0) + 1 < ( this.z2 ??0) ) {
						return ( !Lang13.Bool( Z2 ) || ( Z2 ??0) - ( Z1 ??0) + 1 >= ( this.z2 ??0) ? new ByTable(new object [] { X1, Y1, Z1 }) : null );
					}
					X1 = 1;
					X2 = Game13.map_size_x;
					Y1 = 1;
					Y2 = Game13.map_size_y;
				}
			}
			return _default;
		}

		// Function from file: swapmaps.dm
		public void AllocateSwapMap(  ) {
			ByTable l = null;

			GlobalFuncs.InitializeSwapMaps();
			Game13.map_size_x = Num13.MaxInt( this.x2, Game13.map_size_x );
			Game13.map_size_y = Num13.MaxInt( this.y2, Game13.map_size_y );

			if ( !this.ischunk ) {
				
				if ( Game13.map_size_z <= GlobalVars.swapmaps_compiled_maxz ) {
					this.z1 = GlobalVars.swapmaps_compiled_maxz + 1;
					this.x1 = 1;
					this.y1 = 1;
				} else {
					l = this.ConsiderRegion( 1, 1, Game13.map_size_x, Game13.map_size_y, GlobalVars.swapmaps_compiled_maxz + 1 );
					this.x1 = Convert.ToInt32( l[1] );
					this.y1 = Convert.ToInt32( l[2] );
					this.z1 = Lang13.IntNullable( l[3] );
					Lang13.Delete( l );
					l = null;
				}
			}
			this.x2 += this.x1 - 1;
			this.y2 += this.y1 - 1;
			this.z2 += ( this.z1 ??0) - 1;
			Game13.map_size_z = Num13.MaxInt( this.z2 ??0, Game13.map_size_z );

			if ( !this.ischunk ) {
				GlobalVars.swapmaps_loaded[this] = null;
				GlobalVars.swapmaps_byname[this.id] = this;
			}
			return;
		}

		// Function from file: swapmaps.dm
		public override void Read( SaveFile F = null, dynamic __id = null, dynamic locorner = null ) {
			int x = 0;
			int y = 0;
			int? z = null;
			dynamic n = null;
			dynamic areas = null;
			dynamic defarea = null;
			dynamic dummy = null;
			string oldcd = null;
			dynamic tp = null;
			dynamic T = null;
			dynamic A = null;
			Obj O = null;
			dynamic M = null;

			defarea = Lang13.FindObj( Game13.default_zone );
			this.id = __id;

			if ( Lang13.Bool( locorner ) ) {
				this.ischunk = true;
				this.x1 = Convert.ToInt32( locorner.x );
				this.y1 = Convert.ToInt32( locorner.y );
				this.z1 = Lang13.IntNullable( locorner.z );
			}

			if ( !Lang13.Bool( defarea ) ) {
				defarea = Lang13.Call( Game13.default_zone );
			}

			if ( !Lang13.Bool( __id ) ) {
				this.id = F.ReadItem( "id", this.id );
			} else {
				dummy = F.ReadItem( "id", dummy );
			}
			this.z2 = F.ReadItem( "z", this.z2 );
			this.y2 = F.ReadItem( "y", this.y2 );
			this.x2 = F.ReadItem( "x", this.x2 );
			areas = F.ReadItem( "areas", areas );
			this.locked = true;
			this.AllocateSwapMap();
			oldcd = F.cd;
			z = this.z1;

			while (( z ??0) <= ( this.z2 ??0)) {
				F.cd = "" + ( ( z ??0) - ( this.z1 ??0) + 1 );
				y = this.y1;

				while (y <= this.y2) {
					F.cd = "" + ( y - this.y1 + 1 );
					x = this.x1;

					while (x <= this.x2) {
						F.cd = "" + ( x - this.x1 + 1 );
						tp = null;
						tp = F.ReadItem( "type", tp );
						T = Map13.GetTile( x, y, z ??0 );
						T.loc.contents.Remove( T );
						T = Lang13.Call( tp, Map13.GetTile( x, y, z ??0 ) );

						if ( F.dir.Contains( "AREA" ) ) {
							n = F.ReadItem( "AREA", n );
							A = areas[n];
							A.contents += T;
						} else {
							defarea.contents += T;
						}

						foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj) )) {
							O = _a;
							
							Lang13.Delete( O );
							O = null;
						}

						foreach (dynamic _b in Lang13.Enumerate( T )) {
							M = _b;
							

							if ( !Lang13.Bool( M.key ) ) {
								Lang13.Delete( M );
								M = null;
							} else {
								M.loc = null;
							}
						}
						((Base_Data)T).Read( F );
						F.cd = "..";
						x++;
					}
					F.cd = "..";
					y++;
				}
				Task13.Sleep( 0 );
				F.cd = oldcd;
				z++;
			}
			this.locked = false;
			Lang13.Delete( areas );
			areas = null;
			return;
		}

		// Function from file: swapmaps.dm
		public override void Write( SaveFile F = null ) {
			int x = 0;
			int y = 0;
			int? z = null;
			dynamic n = null;
			ByTable areas = null;
			dynamic defarea = null;
			dynamic T = null;
			string oldcd = null;
			Tile T2 = null;

			defarea = Lang13.FindObj( Game13.default_zone );

			if ( !Lang13.Bool( defarea ) ) {
				defarea = Lang13.Call( Game13.default_zone );
			}
			areas = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( this.x1, this.y1, this.z1 ??0 ), Map13.GetTile( this.x2, this.y2, this.z2 ??0 ) ) )) {
				T = _a;
				
				areas[T.loc] = null;
			}

			foreach (dynamic _b in Lang13.Enumerate( areas )) {
				n = _b;
				
				areas.Remove( n );
				areas.Add( n );
			}
			areas.Remove( defarea );
			GlobalFuncs.InitializeSwapMaps();
			this.locked = true;
			F["id"] = this.id;
			F["z"] = ( this.z2 ??0) - ( this.z1 ??0) + 1;
			F["y"] = this.y2 - this.y1 + 1;
			F["x"] = this.x2 - this.x1 + 1;
			F["areas"] = areas;

			foreach (dynamic _c in Lang13.IterateRange( 1, areas.len )) {
				n = _c;
				
				areas[areas[n]] = n;
			}
			oldcd = F.cd;
			z = this.z1;

			while (( z ??0) <= ( this.z2 ??0)) {
				F.cd = "" + ( ( z ??0) - ( this.z1 ??0) + 1 );
				y = this.y1;

				while (y <= this.y2) {
					F.cd = "" + ( y - this.y1 + 1 );
					x = this.x1;

					while (x <= this.x2) {
						F.cd = "" + ( x - this.x1 + 1 );
						T2 = Map13.GetTile( x, y, z ??0 );
						F["type"] = T2.type;

						if ( T2.loc != defarea ) {
							F["AREA"] = areas[T2.loc];
						}
						T2.Write( F );
						F.cd = "..";
						x++;
					}
					F.cd = "..";
					y++;
				}
				Task13.Sleep( 0 );
				F.cd = oldcd;
				z++;
			}
			this.locked = false;
			Lang13.Delete( areas );
			areas = null;
			return;
		}

		// Function from file: swapmaps.dm
		public override void Del(  ) {
			ByTable areas = null;
			Ent_Static A = null;
			Obj O = null;
			dynamic M = null;
			dynamic a = null;

			
			if ( !this.ischunk ) {
				GlobalVars.swapmaps_loaded.Remove( this );
				GlobalVars.swapmaps_byname.Remove( this.id );

				if ( ( this.z2 ??0) > GlobalVars.swapmaps_compiled_maxz || this.y2 > GlobalVars.swapmaps_compiled_maxy || this.x2 > GlobalVars.swapmaps_compiled_maxx ) {
					areas = new ByTable();

					foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInBlock( Map13.GetTile( this.x1, this.y1, this.z1 ??0 ), Map13.GetTile( this.x2, this.y2, this.z2 ??0 ) ), typeof(Ent_Static) )) {
						A = _c;
						

						foreach (dynamic _a in Lang13.Enumerate( A, typeof(Obj) )) {
							O = _a;
							
							Lang13.Delete( O );
							O = null;
						}

						foreach (dynamic _b in Lang13.Enumerate( A )) {
							M = _b;
							

							if ( !Lang13.Bool( M.key ) ) {
								Lang13.Delete( M );
								M = null;
							} else {
								M.loc = null;
							}
						}
						areas[A.loc] = null;
						Lang13.Delete( A );
						A = null;
					}

					foreach (dynamic _d in Lang13.Enumerate( areas )) {
						a = _d;
						

						if ( Lang13.Bool( a ) && !( a.contents.len != 0 ) ) {
							Lang13.Delete( a );
							a = null;
						}
					}

					if ( this.x2 >= Game13.map_size_x || this.y2 >= Game13.map_size_y || ( this.z2 ??0) >= Game13.map_size_z ) {
						this.CutXYZ();
					}
					Lang13.Delete( areas );
					areas = null;
				}
			}
			base.Del();
			return;
		}

	}

}