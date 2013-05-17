BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs

all: MonoTouch.NativeCSS.dll

libnativeCSS.a:
	@echo "You'll need to obtain a registered copy of libnativeCSS.a from nativecss.com"
	@exit 1

MonoTouch.NativeCSS.dll: Makefile ApiDefinition.cs libnativeCSS.linkwith.cs libnativeCSS.a
	-mkdir -p ios
	$(BTOUCH) -unsafe ApiDefinition.cs --tmpdir=ios --sourceonly ios/sources.list
	$(SMCS) -noconfig -o- -out:MonoTouch.NativeCSS.dll -res:libnativeCSS.a libnativeCSS.linkwith.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll


clean:
	-rm -f MonoTouch.NativeCSS.dll
