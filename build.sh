git clone https://github.com/VizQuick-dev/vq.git
make -C vq
cp vq/libvq.so .
dotnet pack -c Release
