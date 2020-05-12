const jsonEditor = require('gulp-json-editor');

// snip

gulp.task("filesToCache", function () {
    var out = folder.build;
    return gulp.src(folder.src + "filesToCache.json")
        .pipe(jsonEditor(function (json) {
            json.splice(json.indexOf("/styles/inline.css"), 1);
            return json;
        }))
        .pipe(gulp.dest(out));
});