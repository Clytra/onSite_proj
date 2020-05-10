var platform = new H.service.Platform({
    'apikey': 'IxnRh8y0YC2vcWaCevcF'
});

var defaultLayers = platform.createDefaultLayers();

var map = new H.Map(
    document.getElementById('mapContainer'),
    defaultLayers.vector.normal.map,
    {
        zoom: 10,
        center: { lat: 52.5, lng: 13.4 }
    });