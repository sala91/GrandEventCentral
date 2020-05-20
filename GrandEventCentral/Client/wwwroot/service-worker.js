console.log("This is service worker talking!");
var cacheName = 'GrandEventCentral';

self.addEventListener('install', function (e) {
    console.log('[ServiceWorker] Install');
    e.waitUntil(
        caches.open(cacheName).then(function (cache) {
            return fetch("/filesToCache.json").then(function (response) {
                if (response && response.ok) {
                    return response.json()
                }
                throw new Error("Failed to load files to cache for app shell")
            })
                .then(function (filesToCache) {
                    console.log('[ServiceWorker] Caching app shell', filesToCache);
                    return cache.addAll(filesToCache);
                })
                .catch(function (error) {
                    console.error(error);
                })
        })
    );
});

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {
    event.respondWith(
        caches.match(event.request, { ignoreSearch: true }).then(response => {
            return response || fetch(event.request);
        })
    );
});