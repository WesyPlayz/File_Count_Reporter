class File_Count_Reporter
{
    static void Main ()
    {
        string path = "CONTINUE";

        while ( path == "CONTINUE" )
        {
            Console.Write( "Enter a directory path: " );

            path = Console.ReadLine()!;

            if ( !Directory.Exists( path ) )
            {
                Console.WriteLine( "Directory does not exist..." );

                continue;
            }
            string[] files = Directory.GetFiles      ( path, "*.*", SearchOption.AllDirectories );
            string[] fldrs = Directory.GetDirectories( path, "*"  , SearchOption.AllDirectories );

            Console.WriteLine( $"Total files ( including subfolders ) : { files.Length }"     );
            Console.WriteLine( $"Total folders ( including subfolders ) : { fldrs.Length }"   );

            Dictionary < string, int > types = new ( StringComparer.OrdinalIgnoreCase );

            foreach ( string file in files )
            {
                string ext = Path.GetExtension(file);

                if ( types.ContainsKey( ext ) ) types[ ext ]++  ;
                else                            types[ ext ] = 1;
            }
            Console.WriteLine( "\nFile type breakdown :" );

            foreach ( var kvp in types ) Console.WriteLine( $"{ kvp.Key } : { kvp.Value }" );

            while ( path != "EXIT" && path != "CONTINUE" )
            {
                Console.WriteLine( "\nContinue? ( CONTINUE / EXIT )" );

                path = Console.ReadLine()!;

                if ( path != "EXIT" && path != "CONTINUE" ) Console.WriteLine( "Invalid Command..." );
            }
        }
    }
}