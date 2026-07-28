import { useState } from "react";
import { createShortUrl } from "../api/urlApi";

function UrlForm({ loading, setResult, setLoading, setError }) {

    const [url, setUrl] = useState("");

    const handleSubmit = async (e) => {

        e.preventDefault();

        if (!url.trim()) {
            setError("Please enter a URL.");
            return;
        }

        setError("");
        setResult(null);
        setLoading(true);

        try {

            const response = await createShortUrl(url);

            setResult(response.data);

            setUrl("");

        }
        catch (error) {

            setError(
                error.response?.data?.message ||
                "Something went wrong."
            );

        }
        finally {

            setLoading(false);

        }

    };

    return (

        <div className="space-y-4">

            <form onSubmit={handleSubmit} className="space-y-4">

                <div>

                    <label
                        htmlFor="url"
                        className="block text-sm font-medium text-slate-700"
                    >
                        Enter a URL
                    </label>

                    <input
                        id="url"
                        type="url"
                        placeholder="https://example.com"
                        value={url}
                        onChange={(e) => setUrl(e.target.value)}
                        className="
                            mt-2
                            w-full
                            rounded-lg
                            border
                            border-slate-300
                            px-4
                            py-3
                            text-slate-700
                            placeholder:text-slate-400
                            outline-none
                            transition
                            focus:border-blue-500
                            focus:ring-2
                            focus:ring-blue-200
                        "
                    />

                </div>

                <button
                    type="submit"
                    disabled={loading}
                    className="
                        w-full
                        rounded-lg
                        bg-blue-600
                        px-4
                        py-3
                        font-semibold
                        text-white
                        transition
                        hover:bg-blue-700
                        disabled:cursor-not-allowed
                        disabled:bg-slate-400
                    "
                >
                    {loading ? "Shortening..." : "Shorten URL"}
                </button>

            </form>

        </div>

    );
}

export default UrlForm;