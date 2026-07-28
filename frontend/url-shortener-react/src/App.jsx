import { useState } from "react";

import UrlForm from "./components/UrlForm";
import UrlResult from "./components/UrlResult";

function App() {

    const [result, setResult] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");

    return (

        <div className="min-h-screen bg-slate-100 flex items-center justify-center p-6">

            <div className="w-full max-w-2xl rounded-2xl bg-white shadow-xl p-8">

                <h1 className="text-4xl font-bold text-center text-slate-800">
                    🔗 URL Shortener
                </h1>

                <p className="mt-2 text-center text-slate-500">
                    Shorten your long URLs instantly.
                </p>

                <div className="mt-8">

                    <UrlForm
                    loading={loading}
                        setResult={setResult}
                        setLoading={setLoading}
                        setError={setError}
                    />

                </div>

                <div className="mt-8">

                    <UrlResult
                        result={result}
                        loading={loading}
                        error={error}
                    />

                </div>

            </div>

        </div>

    );
}

export default App;