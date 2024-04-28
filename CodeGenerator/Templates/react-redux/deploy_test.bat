echo Copy TerminalTest Start!!!

 set PUBLIC_URL=http://plast-plus.org:55111/terminaltest/&& call npm run build

 xcopy .\build \\192.168.1.120\TerminalTest /s /e /y  

 start "" http://plast-plus.org:55111/terminaltest

echo Copy TerminalTest Finish!!!


