function UrlResult({ result, loading, error }) {
  if (loading) {
    return (
        <div className="rounded-lg border border-blue-200 bg-blue-50 p-4 text-blue-700">
            Shortening URL...
        </div>
    );
}

if (error) {
    return (
        <div className="rounded-lg border border-red-200 bg-red-50 p-4 text-red-700">
            {error}
        </div>
    );
}

if (!result) {
    return null;
}

  const copyToClipboard = async () => {

    try {

        await navigator.clipboard.writeText(result.shortUrl);

        alert("URL copied successfully!");

    } catch {

        alert("Unable to copy URL.");

    }

};

return (

    <div className="rounded-xl border border-green-200 bg-green-50 p-6 shadow-sm">

        <h2 className="text-xl font-semibold text-green-700">
            ✅ Short URL Created Successfully
        </h2>

        <div className="mt-6 space-y-4">

            <div>

                <p className="text-sm font-medium text-slate-500">
                    Original URL
                </p>

                <p className="break-all text-slate-700">
                    {result.originalUrl}
                </p>

            </div>

            <div>

                <p className="text-sm font-medium text-slate-500">
                    Short URL
                </p>

                <a
                    href={result.shortUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="break-all text-blue-600 hover:underline"
                >
                    {result.shortUrl}
                </a>

            </div>

        </div>

<div className="mt-6 flex gap-3">

    <button
        onClick={copyToClipboard}
        className="
            flex-1
            rounded-lg
            bg-blue-600
            px-4
            py-2
            font-medium
            text-white
            transition
            hover:bg-blue-700
        "
    >
        📋 Copy
    </button>

    <a
        href={result.shortUrl}
        target="_blank"
        rel="noopener noreferrer"
        className="
            flex-1
            rounded-lg
            bg-slate-700
            px-4
            py-2
            text-center
            font-medium
            text-white
            transition
            hover:bg-slate-800
        "
    >
        ↗ Open
    </a>

</div>



    </div>

);
}

export default UrlResult;
