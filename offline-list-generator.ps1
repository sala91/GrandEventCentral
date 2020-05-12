$path = "C:\Users\Juurikas\source\repos\GrandEventCentral\GrandEventCentral\Client\bin\Debug\netstandard2.1\wwwroot\_framework\"
DIR $path -Recurse | % {
    $d = "\"
    $o = $_.fullname -replace [regex]::escape($path), (split-path $path -leaf)
    if ( -not $_.psiscontainer) {
        $d = [string]::Empty 
    }
    "$o$d"
}